using ET;
using ProtoBuf;
using System.Collections.Generic;
namespace ET
{
	[Message(OuterOpcode.OpVector3)]
	[ProtoContract]
	public partial class OpVector3: Object
	{
		[ProtoMember(1)]
		public float X { get; set; }

		[ProtoMember(2)]
		public float Y { get; set; }

		[ProtoMember(3)]
		public float Z { get; set; }

	}

	[ResponseType(typeof(M2C_TestResponse))]
	[Message(OuterOpcode.C2M_TestRequest)]
	[ProtoContract]
	public partial class C2M_TestRequest: Object, IActorLocationRequest
	{
		[ProtoMember(1)]
		public int RpcId { get; set; }

		[ProtoMember(2)]
		public string request { get; set; }

	}

	[Message(OuterOpcode.M2C_TestResponse)]
	[ProtoContract]
	public partial class M2C_TestResponse: Object, IActorLocationResponse
	{
		[ProtoMember(1)]
		public int RpcId { get; set; }

		[ProtoMember(2)]
		public int Error { get; set; }

		[ProtoMember(3)]
		public string Message { get; set; }

		[ProtoMember(4)]
		public string response { get; set; }

	}

	[ResponseType(typeof(Actor_TransferResponse))]
	[Message(OuterOpcode.Actor_TransferRequest)]
	[ProtoContract]
	public partial class Actor_TransferRequest: Object, IActorLocationRequest
	{
		[ProtoMember(1)]
		public int RpcId { get; set; }

		[ProtoMember(2)]
		public int MapIndex { get; set; }

	}

	[Message(OuterOpcode.Actor_TransferResponse)]
	[ProtoContract]
	public partial class Actor_TransferResponse: Object, IActorLocationResponse
	{
		[ProtoMember(1)]
		public int RpcId { get; set; }

		[ProtoMember(2)]
		public int Error { get; set; }

		[ProtoMember(3)]
		public string Message { get; set; }

	}

	[ResponseType(typeof(G2C_EnterMap))]
	[Message(OuterOpcode.C2G_EnterMap)]
	[ProtoContract]
	public partial class C2G_EnterMap: Object, IRequest
	{
		[ProtoMember(1)]
		public int RpcId { get; set; }

	}

	[Message(OuterOpcode.G2C_EnterMap)]
	[ProtoContract]
	public partial class G2C_EnterMap: Object, IResponse
	{
		[ProtoMember(1)]
		public int RpcId { get; set; }

		[ProtoMember(2)]
		public int Error { get; set; }

		[ProtoMember(3)]
		public string Message { get; set; }

// 自己的unit id
// 自己的unit id
		[ProtoMember(4)]
		public long UnitId { get; set; }

// 所有的unit
// 所有的unit
		[ProtoMember(5)]
		public List<UnitInfo> Units = new List<UnitInfo>();

	}

	[Message(OuterOpcode.UnitInfo)]
	[ProtoContract]
	public partial class UnitInfo: Object
	{
		[ProtoMember(1)]
		public long UnitId { get; set; }

		[ProtoMember(2)]
		public int ConfigId { get; set; }

		[ProtoMember(3)]
		public OpVector3 Pos { get; set; }

		[ProtoMember(6)]
		public List<int> Ks = new List<int>();

		[ProtoMember(7)]
		public List<long> Vs = new List<long>();

	}

	[Message(OuterOpcode.M2C_CreateUnits)]
	[ProtoContract]
	public partial class M2C_CreateUnits: Object, IActorMessage
	{
		[ProtoMember(1)]
		public int RpcId { get; set; }

		[ProtoMember(2)]
		public List<UnitInfo> Units = new List<UnitInfo>();

	}

	[Message(OuterOpcode.C2M_PathfindingResult)]
	[ProtoContract]
	public partial class C2M_PathfindingResult: Object, IActorLocationMessage
	{
		[ProtoMember(1)]
		public int RpcId { get; set; }

		[ProtoMember(2)]
		public float X { get; set; }

		[ProtoMember(3)]
		public float Y { get; set; }

		[ProtoMember(4)]
		public float Z { get; set; }

	}

	[Message(OuterOpcode.C2M_Stop)]
	[ProtoContract]
	public partial class C2M_Stop: Object, IActorLocationMessage
	{
		[ProtoMember(1)]
		public int RpcId { get; set; }

	}

	[Message(OuterOpcode.M2C_PathfindingResult)]
	[ProtoContract]
	public partial class M2C_PathfindingResult: Object, IActorMessage
	{
		[ProtoMember(1)]
		public long Id { get; set; }

		[ProtoMember(2)]
		public float X { get; set; }

		[ProtoMember(3)]
		public float Y { get; set; }

		[ProtoMember(4)]
		public float Z { get; set; }

		[ProtoMember(5)]
		public List<float> Xs = new List<float>();

		[ProtoMember(6)]
		public List<float> Ys = new List<float>();

		[ProtoMember(7)]
		public List<float> Zs = new List<float>();

	}

	[Message(OuterOpcode.M2C_Stop)]
	[ProtoContract]
	public partial class M2C_Stop: Object, IActorMessage
	{
		[ProtoMember(1)]
		public int Error { get; set; }

		[ProtoMember(2)]
		public long Id { get; set; }

		[ProtoMember(3)]
		public float X { get; set; }

		[ProtoMember(4)]
		public float Y { get; set; }

		[ProtoMember(5)]
		public float Z { get; set; }

		[ProtoMember(6)]
		public float A { get; set; }

		[ProtoMember(7)]
		public float B { get; set; }

		[ProtoMember(8)]
		public float C { get; set; }

		[ProtoMember(9)]
		public float W { get; set; }

	}

	[ResponseType(typeof(G2C_Ping))]
	[Message(OuterOpcode.C2G_Ping)]
	[ProtoContract]
	public partial class C2G_Ping: Object, IRequest
	{
		[ProtoMember(1)]
		public int RpcId { get; set; }

	}

	[Message(OuterOpcode.G2C_Ping)]
	[ProtoContract]
	public partial class G2C_Ping: Object, IResponse
	{
		[ProtoMember(1)]
		public int RpcId { get; set; }

		[ProtoMember(2)]
		public int Error { get; set; }

		[ProtoMember(3)]
		public string Message { get; set; }

		[ProtoMember(4)]
		public long Time { get; set; }

	}

	[Message(OuterOpcode.G2C_Test)]
	[ProtoContract]
	public partial class G2C_Test: Object, IMessage
	{
	}

	[ResponseType(typeof(M2C_Reload))]
	[Message(OuterOpcode.C2M_Reload)]
	[ProtoContract]
	public partial class C2M_Reload: Object, IRequest
	{
		[ProtoMember(1)]
		public int RpcId { get; set; }

		[ProtoMember(2)]
		public string Account { get; set; }

		[ProtoMember(3)]
		public string Password { get; set; }

	}

	[Message(OuterOpcode.M2C_Reload)]
	[ProtoContract]
	public partial class M2C_Reload: Object, IResponse
	{
		[ProtoMember(1)]
		public int RpcId { get; set; }

		[ProtoMember(2)]
		public int Error { get; set; }

		[ProtoMember(3)]
		public string Message { get; set; }

	}

	[ResponseType(typeof(R2C_Login))]
	[Message(OuterOpcode.C2R_Login)]
	[ProtoContract]
	public partial class C2R_Login: Object, IRequest
	{
		[ProtoMember(1)]
		public int RpcId { get; set; }

		[ProtoMember(2)]
		public string Account { get; set; }

		[ProtoMember(3)]
		public string Password { get; set; }

	}

	[Message(OuterOpcode.R2C_Login)]
	[ProtoContract]
	public partial class R2C_Login: Object, IResponse
	{
		[ProtoMember(1)]
		public int RpcId { get; set; }

		[ProtoMember(2)]
		public int Error { get; set; }

		[ProtoMember(3)]
		public string Message { get; set; }

		[ProtoMember(4)]
		public string Address { get; set; }

		[ProtoMember(5)]
		public long Key { get; set; }

		[ProtoMember(6)]
		public long GateId { get; set; }

	}

	[ResponseType(typeof(G2C_LoginGate))]
	[Message(OuterOpcode.C2G_LoginGate)]
	[ProtoContract]
	public partial class C2G_LoginGate: Object, IRequest
	{
		[ProtoMember(1)]
		public int RpcId { get; set; }

		[ProtoMember(2)]
		public long Key { get; set; }

		[ProtoMember(3)]
		public string Account { get; set; }

	}

	[Message(OuterOpcode.G2C_LoginGate)]
	[ProtoContract]
	public partial class G2C_LoginGate: Object, IResponse
	{
		[ProtoMember(1)]
		public int RpcId { get; set; }

		[ProtoMember(2)]
		public int Error { get; set; }

		[ProtoMember(3)]
		public string Message { get; set; }

		[ProtoMember(4)]
		public bool IsCreateRole { get; set; }

	}

	[ResponseType(typeof(G2C_CreateRole))]
	[Message(OuterOpcode.C2G_CreateRole)]
	[ProtoContract]
	public partial class C2G_CreateRole: Object, IRequest
	{
		[ProtoMember(1)]
		public int RpcId { get; set; }

		[ProtoMember(2)]
		public string Name { get; set; }

		[ProtoMember(3)]
		public int Sex { get; set; }

	}

	[Message(OuterOpcode.G2C_CreateRole)]
	[ProtoContract]
	public partial class G2C_CreateRole: Object, IResponse
	{
		[ProtoMember(1)]
		public int RpcId { get; set; }

		[ProtoMember(2)]
		public int Error { get; set; }

		[ProtoMember(3)]
		public string Message { get; set; }

	}

	[Message(OuterOpcode.G2C_TestHotfixMessage)]
	[ProtoContract]
	public partial class G2C_TestHotfixMessage: Object, IMessage
	{
		[ProtoMember(1)]
		public string Info { get; set; }

	}

	[ResponseType(typeof(M2C_TestRobotCase))]
	[Message(OuterOpcode.C2M_TestRobotCase)]
	[ProtoContract]
	public partial class C2M_TestRobotCase: Object, IActorLocationRequest
	{
		[ProtoMember(1)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public int N { get; set; }

	}

	[Message(OuterOpcode.M2C_TestRobotCase)]
	[ProtoContract]
	public partial class M2C_TestRobotCase: Object, IActorLocationResponse
	{
		[ProtoMember(1)]
		public int RpcId { get; set; }

		[ProtoMember(2)]
		public int Error { get; set; }

		[ProtoMember(3)]
		public string Message { get; set; }

		[ProtoMember(4)]
		public int N { get; set; }

	}

	[Message(OuterOpcode.M2C_StartTransfer)]
	[ProtoContract]
	public partial class M2C_StartTransfer: Object, IActorMessage
	{
		[ProtoMember(1)]
		public int MapConfigId { get; set; }

		[ProtoMember(2)]
		public UnitInfo MyUnit { get; set; }

	}

	[Message(OuterOpcode.C2M_TransferEnd)]
	[ProtoContract]
	public partial class C2M_TransferEnd: Object, IActorLocationMessage
	{
		[ProtoMember(1)]
		public int RpcId { get; set; }

	}

	[Message(OuterOpcode.M2C_InitMap)]
	[ProtoContract]
	public partial class M2C_InitMap: Object, IActorMessage
	{
		[ProtoMember(2)]
		public List<UnitInfo> Units = new List<UnitInfo>();

	}

	[ResponseType(typeof(M2C_PutOnEquip))]
	[Message(OuterOpcode.C2M_PutOnEquip)]
	[ProtoContract]
	public partial class C2M_PutOnEquip: Object, IActorLocationRequest
	{
		[ProtoMember(1)]
		public int RpcId { get; set; }

		[ProtoMember(2)]
		public long ItemId { get; set; }

		[ProtoMember(3)]
		public int EquipPoint { get; set; }

	}

	[Message(OuterOpcode.M2C_PutOnEquip)]
	[ProtoContract]
	public partial class M2C_PutOnEquip: Object, IActorLocationResponse
	{
		[ProtoMember(1)]
		public int RpcId { get; set; }

		[ProtoMember(2)]
		public int Error { get; set; }

		[ProtoMember(3)]
		public string Message { get; set; }

	}

	[Message(OuterOpcode.M2C_InventoryUpdate)]
	[ProtoContract]
	public partial class M2C_InventoryUpdate: Object, IActorMessage
	{
		[ProtoMember(1)]
		public List<long> DeleteSet = new List<long>();

		[ProtoMember(2)]
		public List<ItemProto> NewSet = new List<ItemProto>();

	}

	[Message(OuterOpcode.ItemProto)]
	[ProtoContract]
	public partial class ItemProto: Object
	{
		[ProtoMember(1)]
		public int ConfigId { get; set; }

		[ProtoMember(2)]
		public int Num { get; set; }

		[ProtoMember(3)]
		public int Pos { get; set; }

		[ProtoMember(4)]
		public long ItemId { get; set; }

	}

	[Message(OuterOpcode.M2C_EquipUpdate)]
	[ProtoContract]
	public partial class M2C_EquipUpdate: Object, IActorMessage
	{
		[ProtoMember(1)]
		public int EquipPoint { get; set; }

		[ProtoMember(2)]
		public ItemProto Item { get; set; }

	}

	[Message(OuterOpcode.M2C_InitInventory)]
	[ProtoContract]
	public partial class M2C_InitInventory: Object, IActorMessage
	{
		[ProtoMember(1)]
		public List<ItemProto> Items = new List<ItemProto>();

	}

	[ResponseType(typeof(M2C_DeleteItem))]
	[Message(OuterOpcode.C2M_DeleteItem)]
	[ProtoContract]
	public partial class C2M_DeleteItem: Object, IActorLocationRequest
	{
		[ProtoMember(1)]
		public int RpcId { get; set; }

		[ProtoMember(2)]
		public long ItemId { get; set; }

	}

	[Message(OuterOpcode.M2C_DeleteItem)]
	[ProtoContract]
	public partial class M2C_DeleteItem: Object, IActorLocationResponse
	{
		[ProtoMember(1)]
		public int RpcId { get; set; }

		[ProtoMember(2)]
		public int Error { get; set; }

		[ProtoMember(3)]
		public string Message { get; set; }

	}

	[ResponseType(typeof(M2C_PutDownEquip))]
	[Message(OuterOpcode.C2M_PutDownEquip)]
	[ProtoContract]
	public partial class C2M_PutDownEquip: Object, IActorLocationRequest
	{
		[ProtoMember(1)]
		public int RpcId { get; set; }

		[ProtoMember(2)]
		public int EquipPoint { get; set; }

	}

	[Message(OuterOpcode.M2C_PutDownEquip)]
	[ProtoContract]
	public partial class M2C_PutDownEquip: Object, IActorLocationResponse
	{
		[ProtoMember(1)]
		public int RpcId { get; set; }

		[ProtoMember(2)]
		public int Error { get; set; }

		[ProtoMember(3)]
		public string Message { get; set; }

	}

	[ResponseType(typeof(M2C_DeleteEquip))]
	[Message(OuterOpcode.C2M_DeleteEquip)]
	[ProtoContract]
	public partial class C2M_DeleteEquip: Object, IActorLocationRequest
	{
		[ProtoMember(1)]
		public int RpcId { get; set; }

		[ProtoMember(2)]
		public int EquipPoint { get; set; }

	}

	[Message(OuterOpcode.M2C_DeleteEquip)]
	[ProtoContract]
	public partial class M2C_DeleteEquip: Object, IActorLocationResponse
	{
		[ProtoMember(1)]
		public int RpcId { get; set; }

		[ProtoMember(2)]
		public int Error { get; set; }

		[ProtoMember(3)]
		public string Message { get; set; }

	}

	[ResponseType(typeof(M2C_DiscardItem))]
	[Message(OuterOpcode.C2M_DiscardItem)]
	[ProtoContract]
	public partial class C2M_DiscardItem: Object, IActorLocationRequest
	{
		[ProtoMember(1)]
		public int RpcId { get; set; }

		[ProtoMember(2)]
		public long ItemId { get; set; }

		[ProtoMember(3)]
		public OpVector3 Pos { get; set; }

	}

	[Message(OuterOpcode.M2C_DiscardItem)]
	[ProtoContract]
	public partial class M2C_DiscardItem: Object, IActorLocationResponse
	{
		[ProtoMember(1)]
		public int RpcId { get; set; }

		[ProtoMember(2)]
		public int Error { get; set; }

		[ProtoMember(3)]
		public string Message { get; set; }

	}

	[Message(OuterOpcode.M2C_AddUnit)]
	[ProtoContract]
	public partial class M2C_AddUnit: Object, IActorMessage
	{
		[ProtoMember(1)]
		public List<UnitInfo> Units = new List<UnitInfo>();

	}

	[Message(OuterOpcode.M2C_RemoveUnit)]
	[ProtoContract]
	public partial class M2C_RemoveUnit: Object, IActorMessage
	{
		[ProtoMember(1)]
		public List<long> UnitIds = new List<long>();

	}

	[ResponseType(typeof(M2C_PickUpDrop))]
	[Message(OuterOpcode.C2M_PickUpDrop)]
	[ProtoContract]
	public partial class C2M_PickUpDrop: Object, IActorLocationRequest
	{
		[ProtoMember(1)]
		public int RpcId { get; set; }

		[ProtoMember(2)]
		public long UnitId { get; set; }

	}

	[Message(OuterOpcode.M2C_PickUpDrop)]
	[ProtoContract]
	public partial class M2C_PickUpDrop: Object, IActorLocationResponse
	{
		[ProtoMember(1)]
		public int RpcId { get; set; }

		[ProtoMember(2)]
		public int Error { get; set; }

		[ProtoMember(3)]
		public string Message { get; set; }

	}

	[ResponseType(typeof(M2C_ResponseTransfer))]
	[Message(OuterOpcode.C2M_RequestTransfer)]
	[ProtoContract]
	public partial class C2M_RequestTransfer: Object, IActorLocationRequest
	{
		[ProtoMember(1)]
		public int RpcId { get; set; }

		[ProtoMember(2)]
		public int TransferConfigId { get; set; }

	}

	[Message(OuterOpcode.M2C_ResponseTransfer)]
	[ProtoContract]
	public partial class M2C_ResponseTransfer: Object, IActorLocationResponse
	{
		[ProtoMember(1)]
		public int RpcId { get; set; }

		[ProtoMember(2)]
		public int Error { get; set; }

		[ProtoMember(3)]
		public string Message { get; set; }

	}

}
