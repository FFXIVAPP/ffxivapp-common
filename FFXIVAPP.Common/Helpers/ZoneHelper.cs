// FFXIVAPP.Common
// ZoneHelper.cs
// 
// Copyright © 2007 - 2015 Ryan Wilson - All Rights Reserved
// 
// Redistribution and use in source and binary forms, with or without 
// modification, are permitted provided that the following conditions are met: 
// 
//  * Redistributions of source code must retain the above copyright notice, 
//    this list of conditions and the following disclaimer. 
//  * Redistributions in binary form must reproduce the above copyright 
//    notice, this list of conditions and the following disclaimer in the 
//    documentation and/or other materials provided with the distribution. 
//  * Neither the name of SyndicatedLife nor the names of its contributors may 
//    be used to endorse or promote products derived from this software 
//    without specific prior written permission. 
// 
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" 
// AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE 
// IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE 
// ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE 
// LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR 
// CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF 
// SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS 
// INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN 
// CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) 
// ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE 
// POSSIBILITY OF SUCH DAMAGE. 

using System;
using System.Collections.Generic;
using System.Linq;

namespace FFXIVAPP.Common.Helpers
{
    public static class ZoneHelper
    {
        private static IList<MapInfo> _mapInfoList;

        private static IEnumerable<MapInfo> MapInfoList
        {
            get { return _mapInfoList ?? (_mapInfoList = GenerateMapList()); }
        }

        public static MapInfo GetMapInfo(uint index)
        {
            var mapInfo = MapInfoList.FirstOrDefault(m => m.Index == index);
            return mapInfo ?? new MapInfo(false, index);
        }

        private static IList<MapInfo> GenerateMapList()
        {
            var mapList = new List<MapInfo>
            {
                new MapInfo(false, 128)
                {
                    Chinese = "Limsa Lominsa Upper Decks",
                    English = "Limsa Lominsa Upper Decks",
                    French = "Le Tillac",
                    German = "Obere Decks",
                    Japanese = "リムサ・ロミンサ：上甲板層"
                },
                new MapInfo(false, 129)
                {
                    Chinese = "Limsa Lominsa Lower Decks",
                    English = "Limsa Lominsa Lower Decks",
                    French = "L'Entrepont",
                    German = "Untere Decks",
                    Japanese = "リムサ・ロミンサ：下甲板層"
                },
                new MapInfo(false, 130)
                {
                    Chinese = "Ul'dah - Steps of Nald",
                    English = "Ul'dah - Steps of Nald",
                    French = "Ul'dah - faubourg de Nald",
                    German = "Nald-Kreuzgang",
                    Japanese = "ウルダハ：ナル回廊"
                },
                new MapInfo(false, 131)
                {
                    Chinese = "Ul'dah - Steps of Thal",
                    English = "Ul'dah - Steps of Thal",
                    French = "Ul'dah - faubourg de Thal",
                    German = "Thal-Kreuzgang",
                    Japanese = "ウルダハ：ザル回廊"
                },
                new MapInfo(false, 132)
                {
                    Chinese = "New Gridania",
                    English = "New Gridania",
                    French = "Nouvelle Gridania",
                    German = "Neu-Gridania",
                    Japanese = "グリダニア：新市街"
                },
                new MapInfo(false, 133)
                {
                    Chinese = "Old Gridania",
                    English = "Old Gridania",
                    French = "Vieille Gridania",
                    German = "Alt-Gridania",
                    Japanese = "グリダニア：旧市街"
                },
                new MapInfo(false, 134)
                {
                    Chinese = "Middle La Noscea",
                    English = "Middle La Noscea",
                    French = "Noscea centrale",
                    German = "Zentrales La Noscea",
                    Japanese = "中央ラノシア"
                },
                new MapInfo(false, 135)
                {
                    Chinese = "Lower La Noscea",
                    English = "Lower La Noscea",
                    French = "Basse-Noscea",
                    German = "Unteres La Noscea",
                    Japanese = "低地ラノシア"
                },
                new MapInfo(false, 137)
                {
                    Chinese = "Eastern La Noscea",
                    English = "Eastern La Noscea",
                    French = "Noscea orientale",
                    German = "Östliches La Noscea",
                    Japanese = "東ラノシア"
                },
                new MapInfo(false, 138)
                {
                    Chinese = "Western La Noscea",
                    English = "Western La Noscea",
                    French = "Noscea occidentale",
                    German = "Westliches La Noscea",
                    Japanese = "西ラノシア"
                },
                new MapInfo(false, 139)
                {
                    Chinese = "Upper La Noscea",
                    English = "Upper La Noscea",
                    French = "Haute-Noscea",
                    German = "Oberes La Noscea",
                    Japanese = "高地ラノシア"
                },
                new MapInfo(false, 140)
                {
                    Chinese = "Western Thanalan",
                    English = "Western Thanalan",
                    French = "Thanalan occidental",
                    German = "Westliches Thanalan",
                    Japanese = "西ザナラーン"
                },
                new MapInfo(false, 141)
                {
                    Chinese = "Central Thanalan",
                    English = "Central Thanalan",
                    French = "Thanalan central",
                    German = "Zentrales Thanalan",
                    Japanese = "中央ザナラーン"
                },
                new MapInfo(false, 145)
                {
                    Chinese = "Eastern Thanalan",
                    English = "Eastern Thanalan",
                    French = "Thanalan oriental",
                    German = "Östliches Thanalan",
                    Japanese = "東ザナラーン"
                },
                new MapInfo(false, 146)
                {
                    Chinese = "Southern Thanalan",
                    English = "Southern Thanalan",
                    French = "Thanalan méridional",
                    German = "Südliches Thanalan",
                    Japanese = "南ザナラーン"
                },
                new MapInfo(false, 147)
                {
                    Chinese = "Northern Thanalan",
                    English = "Northern Thanalan",
                    French = "Thanalan septentrional",
                    German = "Nördliches Thanalan",
                    Japanese = "北ザナラーン"
                },
                new MapInfo(false, 148)
                {
                    Chinese = "Central Shroud",
                    English = "Central Shroud",
                    French = "Forêt centrale",
                    German = "Tiefer Wald",
                    Japanese = "黒衣森：中央森林"
                },
                new MapInfo(false, 152)
                {
                    Chinese = "East Shroud",
                    English = "East Shroud",
                    French = "Forêt de l'est",
                    German = "Ostwald",
                    Japanese = "黒衣森：東部森林"
                },
                new MapInfo(false, 153)
                {
                    Chinese = "South Shroud",
                    English = "South Shroud",
                    French = "Forêt du sud",
                    German = "Südwald",
                    Japanese = "黒衣森：南部森林"
                },
                new MapInfo(false, 154)
                {
                    Chinese = "North Shroud",
                    English = "North Shroud",
                    French = "Forêt du nord",
                    German = "Nordwald",
                    Japanese = "黒衣森：北部森林"
                },
                new MapInfo(false, 155)
                {
                    Chinese = "Coerthas Central Highlands",
                    English = "Coerthas Central Highlands",
                    French = "Hautes terres du Coerthas central",
                    German = "Zentrales Hochland von Coerthas",
                    Japanese = "クルザス中央高地"
                },
                new MapInfo(false, 156)
                {
                    Chinese = "Mor Dhona",
                    English = "Mor Dhona",
                    French = "Mor Dhona",
                    German = "Mor Dhona",
                    Japanese = "モードゥナ"
                },
                new MapInfo(true, 157)
                {
                    Chinese = "Sastasha",
                    English = "Sastasha",
                    French = "Sastasha",
                    German = "Sastasha-Höhle",
                    Japanese = "サスタシャ浸食洞"
                },
                new MapInfo(true, 158)
                {
                    Chinese = "Brayflox's Longstop",
                    English = "Brayflox's Longstop",
                    French = "Bivouac de Brayflox",
                    German = "Brüllvolx' Langrast",
                    Japanese = "ブレイフロクスの野営地"
                },
                new MapInfo(true, 159)
                {
                    Chinese = "The Wanderer's Palace",
                    English = "The Wanderer's Palace",
                    French = "Palais du Vagabond",
                    German = "Palast des Wanderers",
                    Japanese = "ワンダラーパレス"
                },
                new MapInfo(true, 160)
                {
                    Chinese = "Pharos Sirius",
                    English = "Pharos Sirius",
                    French = "Phare de Sirius",
                    German = "Pharos Sirius",
                    Japanese = "シリウス大灯台"
                },
                new MapInfo(true, 161)
                {
                    Chinese = "Copperbell Mines",
                    English = "Copperbell Mines",
                    French = "Mines de Clochecuivre",
                    German = "Kupferglocken-Mine",
                    Japanese = "カッパーベル銅山"
                },
                new MapInfo(true, 162)
                {
                    Chinese = "Halatali",
                    English = "Halatali",
                    French = "Halatali",
                    German = "Halatali",
                    Japanese = "ハラタリ修練所"
                },
                new MapInfo(true, 163)
                {
                    Chinese = "The Sunken Temple of Qarn",
                    English = "The Sunken Temple of Qarn",
                    French = "Temple enseveli de Qarn",
                    German = "Versunkener Tempel von Qarn",
                    Japanese = "カルン埋没寺院 "
                },
                new MapInfo(true, 164)
                {
                    Chinese = "The Tam-Tara Deepcroft",
                    English = "The Tam-Tara Deepcroft",
                    French = "Hypogée de Tam-Tara",
                    German = "Totenacker Tam-Tara",
                    Japanese = "タムタラの墓所"
                },
                new MapInfo(true, 166)
                {
                    Chinese = "Haukke Manor",
                    English = "Haukke Manor",
                    French = "Manoir des Haukke",
                    German = "Haukke-Herrenhaus",
                    Japanese = "ハウケタ御用邸"
                },
                new MapInfo(true, 167)
                {
                    Chinese = "Amdapor Keep",
                    English = "Amdapor Keep",
                    French = "Château d'Amdapor",
                    German = "Ruinen von Amdapor",
                    Japanese = "古城アムダプール"
                },
                new MapInfo(true, 168)
                {
                    Chinese = "Stone Vigil",
                    English = "Stone Vigil",
                    French = "Vigile de pierre",
                    German = "Steinerne Wacht",
                    Japanese = "ストーンヴィジル"
                },
                new MapInfo(true, 169)
                {
                    Chinese = "The Thousand Maws of Toto-Rak",
                    English = "The Thousand Maws of Toto-Rak",
                    French = "Mille Gueules de Toto-Rak",
                    German = "Tausend Löcher von Toto-Rak",
                    Japanese = "トトラクの千獄"
                },
                new MapInfo(true, 170)
                {
                    Chinese = "Cutter's Cry",
                    English = "Cutter's Cry",
                    French = "Gouffre hurlant",
                    German = "Sägerschrei",
                    Japanese = "カッターズクライ"
                },
                new MapInfo(true, 171)
                {
                    Chinese = "Dzemael Darkhold",
                    English = "Dzemael Darkhold",
                    French = "Forteresse de Dzemael",
                    German = "Feste Dzemael",
                    Japanese = "ゼーメル要塞"
                },
                new MapInfo(true, 172)
                {
                    Chinese = "Aurum Vale",
                    English = "Aurum Vale",
                    French = "Val d'aurum",
                    German = "Goldklamm",
                    Japanese = "オーラムヴェイル"
                },
                new MapInfo(true, 174)
                {
                    Chinese = "Labyrinth of the Ancients",
                    English = "Labyrinth of the Ancients",
                    French = "Dédale antique",
                    German = "Labyrinth der Alten",
                    Japanese = "古代の民の迷宮"
                },
                new MapInfo(true, 175)
                {
                    Chinese = "The Wolves' Den",
                    English = "The Wolves' Den",
                    French = "L'Antre des loups",
                    German = "Die Wolfshöhle",
                    Japanese = "ウルヴズジェイル"
                },
                new MapInfo(false, 177)
                {
                    Chinese = "Mizzenmast Inn",
                    English = "Mizzenmast Inn",
                    French = "Auberge de l'Artimon",
                    German = "Gasthaus Gaffelschoner",
                    Japanese = "宿屋「ミズンマスト」"
                },
                new MapInfo(false, 178)
                {
                    Chinese = "The Hourglass",
                    English = "The Hourglass",
                    French = "Le Sablier",
                    German = "Die Sanduhr",
                    Japanese = "宿屋「砂時計亭」"
                },
                new MapInfo(false, 179)
                {
                    Chinese = "The Roost",
                    English = "The Roost",
                    French = "Le Perchoir",
                    German = "Der Traumbaum",
                    Japanese = "旅館「とまり木」"
                },
                new MapInfo(false, 180)
                {
                    Chinese = "Outer La Noscea",
                    English = "Outer La Noscea",
                    French = "Noscea extérieure",
                    German = "Äußeres La Noscea",
                    Japanese = "外地ラノシア"
                },
                new MapInfo(false, 198)
                {
                    Chinese = "Command Room",
                    English = "Command Room",
                    French = "Salle de l'Amiral",
                    German = "Admiralsbrücke",
                    Japanese = "アドミラルブリッジ：提督室"
                },
                new MapInfo(false, 199)
                {
                    Chinese = "リムサ・ロミンサ会議部屋",
                    English = "リムサ・ロミンサ会議部屋",
                    French = "リムサ・ロミンサ会議部屋",
                    German = "Besprechungszimmer",
                    Japanese = "リムサ・ロミンサ会議部屋"
                },
                new MapInfo(false, 200)
                {
                    Chinese = "リムサ・ロミンサ演説部屋",
                    English = "リムサ・ロミンサ演説部屋",
                    French = "リムサ・ロミンサ演説部屋",
                    German = "Verkündungszimmer",
                    Japanese = "リムサ・ロミンサ演説部屋"
                },
                new MapInfo(true, 202)
                {
                    Chinese = "Bowl of Embers",
                    English = "Bowl of Embers",
                    French = "Cratère des tisons",
                    German = "Das Grab der Lohe",
                    Japanese = "炎帝祭跡"
                },
                new MapInfo(false, 204)
                {
                    Chinese = "Seat of the First Bow",
                    English = "Seat of the First Bow",
                    French = "Salle de commandement du Carquois",
                    German = "Kommandozimmer von Nophicas Schar ",
                    Japanese = "神勇隊司令室"
                },
                new MapInfo(false, 205)
                {
                    Chinese = "Lotus Stand",
                    English = "Lotus Stand",
                    French = "Chaire du lotus",
                    German = "Wasserrosentisch",
                    Japanese = "不語仙の座卓"
                },
                new MapInfo(true, 206)
                {
                    Chinese = "The Navel",
                    English = "The Navel",
                    French = "Le Nombril",
                    German = "Der Nabel",
                    Japanese = "オ・ゴモロ火口神殿"
                },
                new MapInfo(true, 207)
                {
                    Chinese = "Thornmarch",
                    English = "Thornmarch",
                    French = "Lisière de ronces",
                    German = "Dornmarsch",
                    Japanese = "茨の園"
                },
                new MapInfo(true, 208)
                {
                    Chinese = "The Howling Eye",
                    English = "The Howling Eye",
                    French = "Hurlœil",
                    German = "Das Tosende Auge",
                    Japanese = "ハウリングアイ石塔群"
                },
                new MapInfo(false, 210)
                {
                    Chinese = "Heart of the Sworn",
                    English = "Heart of the Sworn",
                    French = "Hall d'argent",
                    German = "Hauptquartier der Palastwache",
                    Japanese = "銀冑団総長室"
                },
                new MapInfo(false, 211)
                {
                    Chinese = "The Fragrant Chamber",
                    English = "The Fragrant Chamber",
                    French = "Chambre de l'encens",
                    German = "Die Weihrauchkammer",
                    Japanese = "香煙の間"
                },
                new MapInfo(false, 212)
                {
                    Chinese = "The Waking Sands",
                    English = "The Waking Sands",
                    French = "Refuge des sables",
                    German = "Sonnenwind",
                    Japanese = "砂の家"
                },
                new MapInfo(true, 217)
                {
                    Chinese = "Castrum Meridianum",
                    English = "Castrum Meridianum",
                    French = "Castrum Meridianum",
                    German = "Castrum Meridianum",
                    Japanese = "カストルム・メリディアヌム"
                },
                new MapInfo(true, 224)
                {
                    Chinese = "Praetorium",
                    English = "Praetorium",
                    French = "Praetorium",
                    German = "Praetorium",
                    Japanese = "魔導城プラエトリウム"
                },
                new MapInfo(false, 241)
                {
                    Chinese = "Upper Aetheroacoustic Exploratory Site",
                    English = "Upper Aetheroacoustic Exploratory Site",
                    French = "Site impérial d'exploration supérieur",
                    German = "Obere ätheroakustische Grabung",
                    Japanese = "メテオ探査坑浅部"
                },
                new MapInfo(false, 242)
                {
                    Chinese = "Lower Aetheroacoustic Exploratory Site",
                    English = "Lower Aetheroacoustic Exploratory Site",
                    French = "Site impérial d'exploration inférieur",
                    German = "Untere ätheroakustische Grabung",
                    Japanese = "メテオ探査坑深部"
                },
                new MapInfo(false, 243)
                {
                    Chinese = "The Ragnarok",
                    English = "The Ragnarok",
                    French = "Le Ragnarok",
                    German = "Die Ragnarök",
                    Japanese = "ラグナロク級拘束艦"
                },
                new MapInfo(false, 244)
                {
                    Chinese = "Ragnarok Drive Cylinder",
                    English = "Ragnarok Drive Cylinder",
                    French = "Cylindre propulseur du Ragnarok",
                    German = "Antriebszylinder der Ragnarök",
                    Japanese = "稼働隔壁"
                },
                new MapInfo(false, 245)
                {
                    Chinese = "Ragnarok Central Core",
                    English = "Ragnarok Central Core",
                    French = "Noyau central du Ragnarok",
                    German = "Kernsektor der Ragnarök",
                    Japanese = "中枢区画"
                },
                new MapInfo(false, 250)
                {
                    Chinese = "Wolves' Den Pier",
                    English = "Wolves' Den Pier",
                    French = "Jetée de l'Antre des loups",
                    German = "Wolfshöhlen-Pier",
                    Japanese = "ウルヴズジェイル係船場"
                },
                new MapInfo(false, 282)
                {
                    Chinese = "Private Cottage - Mist",
                    English = "Private Cottage - Mist",
                    French = "Maisonnette - Brumée",
                    German = "Privathütte (Dorf des Nebels)",
                    Japanese = "ミスト・ヴィレッジ：コテージ"
                },
                new MapInfo(false, 283)
                {
                    Chinese = "Private House - Mist",
                    English = "Private House - Mist",
                    French = "Pavillon - Brumée",
                    German = "Privathaus (Dorf des Nebels)",
                    Japanese = "ミスト・ヴィレッジ：ハウス"
                },
                new MapInfo(false, 284)
                {
                    Chinese = "Private Mansion - Mist",
                    English = "Private Mansion - Mist",
                    French = "Villa - Brumée",
                    German = "Privatresidenz (Dorf des Nebels)",
                    Japanese = "ミスト・ヴィレッジ：レジデンス"
                },
                new MapInfo(true, 331)
                {
                    Chinese = "The Howling Eye",
                    English = "The Howling Eye",
                    French = "Hurlœil",
                    German = "Das Tosende Auge",
                    Japanese = "ハウリングアイ外縁"
                },
                new MapInfo(false, 339)
                {
                    Chinese = "Mist",
                    English = "Mist",
                    French = "Brumée",
                    German = "Dorf des Nebels",
                    Japanese = "ミスト・ヴィレッジ"
                },
                new MapInfo(false, 340)
                {
                    Chinese = "Lavender Beds",
                    English = "Lavender Beds",
                    French = "Lavandière",
                    German = "Lavendelbeete",
                    Japanese = "ラベンダーベッド"
                },
                new MapInfo(false, 341)
                {
                    Chinese = "The Goblet",
                    English = "The Goblet",
                    French = "La Coupe",
                    German = "Kelchkuppe",
                    Japanese = "ゴブレットビュート"
                },
                new MapInfo(false, 342)
                {
                    Chinese = "Private Cottage - Lavender Beds",
                    English = "Private Cottage - Lavender Beds",
                    French = "Maisonnette - Lavandière",
                    German = "Privathütte (Lavendelbeete)",
                    Japanese = "ラベンダーベッド：コテージ"
                },
                new MapInfo(false, 343)
                {
                    Chinese = "Private House - Lavender Beds",
                    English = "Private House - Lavender Beds",
                    French = "Pavillon - Lavandière",
                    German = "Privathaus (Lavendelbeete)",
                    Japanese = "ラベンダーベッド：ハウス"
                },
                new MapInfo(false, 344)
                {
                    Chinese = "Private Mansion - Lavender Beds",
                    English = "Private Mansion - Lavender Beds",
                    French = "Villa - Lavandière",
                    German = "Privatresidenz (Lavendelbeete)",
                    Japanese = "ラベンダーベッド：レジデンス"
                },
                new MapInfo(false, 345)
                {
                    Chinese = "Private Cottage - The Goblet",
                    English = "Private Cottage - The Goblet",
                    French = "Maisonnette - la Coupe",
                    German = "Privathütte (Kelchkuppe)",
                    Japanese = "ゴブレットビュート：コテージ"
                },
                new MapInfo(false, 346)
                {
                    Chinese = "Private House - The Goblet",
                    English = "Private House - The Goblet",
                    French = "Pavillon - la Coupe",
                    German = "Privathaus (Kelchkuppe)",
                    Japanese = "ゴブレットビュート：ハウス"
                },
                new MapInfo(false, 347)
                {
                    Chinese = "Private Mansion - The Goblet",
                    English = "Private Mansion - The Goblet",
                    French = "Villa - la Coupe",
                    German = "Privatresidenz (Kelchkuppe)",
                    Japanese = "ゴブレットビュート：レジデンス"
                },
                new MapInfo(false, 348)
                {
                    Chinese = "Porta Decumana",
                    English = "Porta Decumana",
                    French = "Porta decumana",
                    German = "Porta Decumana",
                    Japanese = "ポルタ・デクマーナ"
                },
                new MapInfo(true, 349)
                {
                    Chinese = "Copperbell Mines (Hard)",
                    English = "Copperbell Mines (Hard)",
                    French = "Mines de Clochecuivre (brutal)",
                    German = "Kupferglocken-Mine (schwer)",
                    Japanese = "カッパーベル銅山（騒乱坑道）"
                },
                new MapInfo(true, 350)
                {
                    Chinese = "Haukke Manor (Hard)",
                    English = "Haukke Manor (Hard)",
                    French = "Manoir des Haukke (brutal)",
                    German = "Haukke-Herrenhaus (schwer)",
                    Japanese = "ハウケタ御用邸（妖異屋敷）"
                },
                new MapInfo(false, 351)
                {
                    Chinese = "The Rising Stones",
                    English = "The Rising Stones",
                    French = "Refuge des roches",
                    German = "Sonnenstein",
                    Japanese = "石の家"
                }
            };

            return mapList;
        }

        public class MapInfo
        {
            private string _chinese;
            private string _english;
            private string _french;
            private string _german;
            private string _japanese;

            /// <summary>
            /// </summary>
            /// <param name="isDunegonInstance"></param>
            /// <param name="index"></param>
            /// <param name="english"></param>
            /// <param name="french"></param>
            /// <param name="japanese"></param>
            /// <param name="german"></param>
            /// <param name="chinese"></param>
            public MapInfo(bool isDunegonInstance, uint index = 0, string english = null, string french = null, string german = null, string japanese = null, string chinese = null)
            {
                Index = index;
                IsDungeonInstance = isDunegonInstance;
                English = english;
                French = french;
                Japanese = japanese;
                German = german;
                Chinese = chinese;
            }

            public uint Index { get; set; }

            public bool IsDungeonInstance { get; set; }

            public string English
            {
                get { return _english ?? String.Format("Unknown_{0}", Index); }
                set { _english = value; }
            }

            public string French
            {
                get { return _french ?? String.Format("Unknown_{0}", Index); }
                set { _french = value; }
            }

            public string Japanese
            {
                get { return _japanese ?? String.Format("Unknown_{0}", Index); }
                set { _japanese = value; }
            }

            public string German
            {
                get { return _german ?? String.Format("Unknown_{0}", Index); }
                set { _german = value; }
            }

            public string Chinese
            {
                get { return _chinese ?? String.Format("Unknown_{0}", Index); }
                set { _chinese = value; }
            }
        }
    }
}
