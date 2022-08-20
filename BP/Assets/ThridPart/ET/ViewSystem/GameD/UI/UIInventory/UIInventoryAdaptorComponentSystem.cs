using ET;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace ET
{
	[ObjectSystem]
	public class UIInventoryAdaptorComponentAwakeSystem : AwakeSystem<UIInventoryAdaptorComponent,ReferenceCollector>
	{
		public override void Awake(UIInventoryAdaptorComponent self,ReferenceCollector rc)
		{
			self.Awake(rc);
		}
	}
	[ObjectSystem]
	public class UIInventoryAdaptorComponentDestroySystem : DestroySystem<UIInventoryAdaptorComponent>
	{
		public override void Destroy(UIInventoryAdaptorComponent self)
		{
			
		}
	}

	public static class UIInventoryAdaptorComponentSystem
	{
		public static void Awake(this UIInventoryAdaptorComponent self,ReferenceCollector rc)
		{
			self.ViewCom.Item_GameObject.SetActive(false);
			for (int i = 0; i < InventoryComponent.MaxItem; i++)
			{
				var go = GameObject.Instantiate(self.ViewCom.Item_GameObject, self.ViewCom.Inventory_GridLayoutGroup.transform);
				self.Pos2Grid.Add(i,go);
				go.SetActive(true);
				var button = go.transform.Find("Bg").GetComponent<Button>();
				button.onClick.RemoveAllListeners();
				var pos = i;
				button.onClick.AddListener(() => OnInventoryGridClick(self, pos));
			}
			self.ViewCom.Inventory_GridLayoutGroup.SetLayoutHorizontal();
			self.ViewCom.Inventory_GridLayoutGroup.SetLayoutVertical();

			self.EquipPoint2Go[(int) EquipPointType.Primary] = self.ViewCom.Primacy_GameObject;
			self.EquipPoint2Go[(int) EquipPointType.SecWeapon] = self.ViewCom.SecondWeapon_GameObject;
			self.EquipPoint2Go[(int) EquipPointType.Coat] = self.ViewCom.Coat_GameObject;
			self.EquipPoint2Go[(int) EquipPointType.Pants] = self.ViewCom.Pants_GameObject;
			self.EquipPoint2Go[(int) EquipPointType.Glove] = self.ViewCom.Glove_GameObject;
			self.EquipPoint2Go[(int) EquipPointType.Shoe] = self.ViewCom.Shoe_GameObject;
			self.EquipPoint2Go[(int) EquipPointType.Belt] = self.ViewCom.Belt_GameObject;
			self.EquipPoint2Go[(int) EquipPointType.Necklace] = self.ViewCom.Necklace_GameObject;
			self.EquipPoint2Go[(int) EquipPointType.Ring1] = self.ViewCom.Ring_L_GameObject;
			self.EquipPoint2Go[(int) EquipPointType.Ring2] = self.ViewCom.Ring_R_GameObject;

			foreach (var v in self.EquipPoint2Go)
			{
				var go = v.Value;
				var button = go.transform.Find("Item/Bg").GetComponent<Button>();
				button.onClick.RemoveAllListeners();
				var pos = v.Key;
				button.onClick.AddListener(() => OnEquipClick(self, pos));
			}
			
			
			// 根据道具栏和装备栏的状态进行显示
	
			self.RefreshInventory();
			self.RefreshEquipCom();
			
			// 刷新按钮事件
			self.ViewCom.Sort_AddListener(self.Sort);
			self.ViewCom.Close_AddListener(self.Close);
		}
		
		static async ETTask Load(this UIInventoryAdaptorComponent self,Image img, string resName)
		{
			await ETTask.CompletedTask;
		}

		public static void RefreshInventory(this UIInventoryAdaptorComponent self)
		{
			var myUnit = self.CurrScene().GetComponent<UnitComponent>().MyUnit;
			var inventory = myUnit.GetComponent<InventoryComponent>();
			foreach (var v in inventory.Pos2Item)
			{
				self.Inventory_Add(v.Key,v.Value);
			}
		}

		public static void RefreshEquipCom(this UIInventoryAdaptorComponent self)
		{
			var myUnit = self.CurrScene().GetComponent<UnitComponent>().MyUnit;
			var equipComponent = myUnit.GetComponent<EquipComponent>();
			List<ETTask> AllTasks = new List<ETTask>(equipComponent.AllEquips.Count);
			foreach (var v in equipComponent.AllEquips)
			{
				var go = self.EquipPoint2Go[v.Key];
				var icon = go.transform.Find("Item/Icon").GetComponent<Image>();
				AllTasks.Add(self.Load(icon, v.Value.ItemConfig.Res));
			}
			ETTaskHelper.WaitAll(AllTasks).Coroutine();
		}

		public static void Inventory_Add(this UIInventoryAdaptorComponent self, int pos, Item item)
		{
			var go = self.Pos2Grid[pos];
			var icon = go.transform.Find("Icon").GetComponent<Image>();
			var num = go.transform.Find("Num").GetComponent<Text>();

			if (item.Num == 1)
			{
				num.gameObject.SetActive(false);
			}
			else
			{
				num.gameObject.SetActive(true);
				num.text = item.Num.ToString();
			}
			self.Load(icon,item.ItemConfig.Res).Coroutine();
		}

		public static void Inventory_Remove(this UIInventoryAdaptorComponent self, int pos)
		{
			var go = self.Pos2Grid[pos];
			var icon = go.transform.Find("Icon").GetComponent<Image>();
			icon.sprite = self.ViewCom.DefaultSprite_Sprite;
			go.transform.Find("Num").gameObject.SetActive(false);
			// var button = go.transform.Find("Bg").GetComponent<Button>();
			// button.onClick.RemoveAllListeners();
		}

		static void OnInventoryGridClick(this UIInventoryAdaptorComponent self,int pos)
		{
			var myUnit = self.CurrScene().GetComponent<UnitComponent>().MyUnit;
			var inventory = myUnit.GetComponent<InventoryComponent>();
			if(!inventory.Pos2Item.TryGetValue(pos,out var item))
				return;
			if (item.ItemConfig.ItemClass != (int) ItemClass.Equip)
				return;
			InventoryHelper.PutOnEquip(inventory, item).Coroutine();
		}

		public static void Equip_Add(this UIInventoryAdaptorComponent self, int EquipPointType,Item item)
		{
			var go = self.EquipPoint2Go[EquipPointType];
			var icon = go.transform.Find("Item/Icon").GetComponent<Image>();
			self.Load(icon, item.ItemConfig.Res).Coroutine();
		}

		public static void Equip_Remove(this UIInventoryAdaptorComponent self, int EquipPointType)
		{
			var go = self.EquipPoint2Go[EquipPointType];
			var icon = go.transform.Find("Item/Icon").GetComponent<Image>();
			icon.sprite = self.ViewCom.DefaultSprite_Sprite;
		}

		static void OnEquipClick(this UIInventoryAdaptorComponent self,int equipPointType)
		{
			var myUnit = self.CurrScene().GetComponent<UnitComponent>().MyUnit;
			var equipComponent = myUnit.GetComponent<EquipComponent>();
			if(!equipComponent.AllEquips.TryGetValue(equipPointType,out var item))
				return;
			InventoryHelper.PutDownEquip(equipComponent, equipPointType).Coroutine();
		}


		public static async ETTask Sort(this UIInventoryAdaptorComponent self)
		{
			await ETTask.CompletedTask;
		}
		
		public static async ETTask Close(this UIInventoryAdaptorComponent self)
		{
			await ETTask.CompletedTask;
			self.Domain.GetComponent<UIComponent>().Remove(UIType.UIInventory);
		}
	}
}
