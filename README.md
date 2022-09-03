# BattlePipeline
BattlePipeline for games

<div id="top"></div>
<!--
*** Thanks for checking out the Best-README-Template. If you have a suggestion
*** that would make this better, please fork the repo and create a pull request
*** or simply open an issue with the tag "enhancement".
*** Don't forget to give the project a star!
*** Thanks again! Now go create something AMAZING! :D
-->



<!-- PROJECT SHIELDS -->
<!--
*** I'm using markdown "reference style" links for readability.
*** Reference links are enclosed in brackets [ ] instead of parentheses ( ).
*** See the bottom of this document for the declaration of the reference variables
*** for contributors-url, forks-url, etc. This is an optional, concise syntax you may use.
*** https://www.markdownguide.org/basic-syntax/#reference-style-links
-->


<!-- ABOUT THE PROJECT -->
## 简单概述
* 这是一个战斗管线，主要处理伤害顺序，结算流程和相关的模块依赖。
* 其实一直想对以前用过，能用但是臃肿的战斗流程进行全面翻新，但是那个系统修修补补好多次，其实也没那么不堪，所以一直没往前推进（其实是懒狗）。
* 目前在筹备阶段，本库当前的主要任务是记录游戏中碰到的各类需求。（别急，你别急）

<p align="right">(<a href="#top">back to top</a>)</p>



<!-- ABOUT THE PROJECT -->
## 目标
1. 新的战斗管线会仿照URP管线处理feature的方式，支持随意插入和修改新的战斗功能以及流程。

<p align="right">(<a href="#top">back to top</a>)</p>


<!-- ABOUT THE PROJECT -->
## 需求记录
* 塞恩的护盾会在装备给与的护盾之后进行进行伤害。
* 老版大改后的剑魔复活会在时光老头的大之后消耗，然后会是复活甲，最后才是本体，再后面才会是掘墓或者铁男。
* 铁男和掘墓同时给大，会产生两个尸体。
* 固伤aoe技能要先判断范围内敌人数量，后面才给伤害。
<p align="right">(<a href="#top">back to top</a>)</p>


<!-- ABOUT THE PROJECT -->
## 一些想法
- 向目标冲刺，向目标点冲刺，冲刺一段时间，冲刺一段距离，冲刺给定的力，写在同一个buff里吗？
- 伤害管线流程：技能给伤害，伤害减去减伤，扣血。这时候发起人的技能虚弱，伤害吸血，吸血减疗，治疗增强，减疗衰减，治疗反转，减伤数值累积监听，目标的伤害反伤，反伤吸血，伤害回血这些怎么处理。都在同一帧处理吗？同一帧处理的话，顺序是什么，技能本身的优先级还是在流程中的时间点顺序。下一帧处理的话，如果目标或者自己死亡，会丢伤害吗？有的技能要人活着才有，有的不用，这两点在比如，我的种子技能在吸血，但是对面也有反伤，种子需要我活着也需要对面活着，但是反伤不需要，这时候两者都丝血，是先吸死还是反伤死，还是一起死。

<p align="right">(<a href="#top">back to top</a>)</p>


<!-- ACKNOWLEDGMENTS -->
## 注意
 目前引用的插件有：

* Animacer
* Dotween Pro
* Odin 
* Slate

<p align="right">(<a href="#top">back to top</a>)</p>


<!-- ACKNOWLEDGMENTS -->
## 参考
* [如何实现一个灵活、通用的战斗（技能）系统](https://zhuanlan.zhihu.com/p/272216809)
* [如何设计一个易扩展的游戏技能系统？](https://www.zhihu.com/question/29545727/answer/789247986)
* [一个MMORPG的常规技能系统](https://zhuanlan.zhihu.com/p/26077188)
* [MMORPG技能管线设计经验总结](https://zhuanlan.zhihu.com/p/551229626)
* [如何实现一个强大的MMO技能系统](https://zhuanlan.zhihu.com/p/147681650)
* [MMORPG技能管线设计经验总结](https://zhuanlan.zhihu.com/p/551229626)
* [Buff机制及其实际运用](https://bbs.gameres.com/forum.php?mod=viewthread&tid=215027)
* [AOE机制的DSL及其实际运用](https://bbs.gameres.com/forum.php?mod=viewthread&tid=225054)
* [不要用海量表项压垮“技能流程”](https://bbs.gameres.com/forum.php?mod=viewthread&tid=229210)
* [Dreamscaper: Killer Combat on an Indie Budget](https://www.youtube.com/watch?v=3Omb5exWpd4)
* [AbilitySystem](https://github.com/weichx/AbilitySystem)
* [EGamePlay](https://github.com/m969/EGamePlay)
* [ET](https://github.com/egametang/ET)

<p align="right">(<a href="#top">back to top</a>)</p>