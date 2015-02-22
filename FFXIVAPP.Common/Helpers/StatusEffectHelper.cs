// FFXIVAPP.Common
// StatusEffectHelper.cs
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

using System.Collections.Generic;
using System.Linq;

namespace FFXIVAPP.Common.Helpers
{
    public static class StatusEffectHelper
    {
        private static Dictionary<short, StatusItem> _statusEffects;
  
        private static Dictionary<short, StatusItem> StatusEffects
        {
            get { return _statusEffects ?? (_statusEffects = new Dictionary<short, StatusItem>()); }
            set
            {
                if (_statusEffects == null)
                {
                    _statusEffects = new Dictionary<short, StatusItem>();
                }
                _statusEffects = value;
            }
        }

        public static StatusItem StatusInfo(short id)
        {
            lock (StatusEffects)
            {
                if (!StatusEffects.Any())
                {
                    Generate();
                }
                if (StatusEffects.ContainsKey(id))
                {          
                    return StatusEffects[id];
                }
                return new StatusItem
                {
                    Name = new StatusLocalization
                    {
                        Chinese = "???",
                        English = "???",
                        French = "???",
                        German = "???",
                        Japanese = "???"
                    },
                    CompanyAction = false
                };
            }
        }

        private static void Generate()
        {
            StatusEffects.Add(1, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "石化",
                    English = "Petrification",
                    French = "Pétrification",
                    German = "Stein",
                    Japanese = "石化"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(2, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "昏迷",
                    English = "Stun",
                    French = "Étourdissement",
                    German = "Betäubung",
                    Japanese = "スタン"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(3, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "睡眠",
                    English = "Sleep",
                    French = "Sommeil",
                    German = "Schlaf",
                    Japanese = "睡眠"
                },
                CompanyAction = true,
            });
            StatusEffects.Add(4, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "眩晕",
                    English = "Daze",
                    French = "Évanouissement",
                    German = "Benommenheit",
                    Japanese = "気絶"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(5, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Amnesia",
                    English = "Amnesia",
                    French = "Amnésie",
                    German = "Amnesie",
                    Japanese = "アビリティ不可"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(6, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Pacification",
                    English = "Pacification",
                    French = "Pacification",
                    German = "Pacem",
                    Japanese = "ＷＳ不可"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(7, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "沉默",
                    English = "Silence",
                    French = "Silence",
                    German = "Stumm",
                    Japanese = "沈黙"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(8, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "加速",
                    English = "Haste",
                    French = "Hâte",
                    German = "Hast",
                    Japanese = "ヘイスト"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(9, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "减速",
                    English = "Slow",
                    French = "Lenteur",
                    German = "Gemach",
                    Japanese = "スロウ"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(10, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "减速",
                    English = "Slow",
                    French = "Lenteur neurolienne",
                    German = "Gemach",
                    Japanese = "拘束装置：スロウ"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(11, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "混乱",
                    English = "Confused",
                    French = "Confusion",
                    German = "Konfus",
                    Japanese = "混乱"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(12, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Levitation",
                    English = "Levitation",
                    French = "Lévitation",
                    German = "Levitation",
                    Japanese = "レビテト"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(13, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "束缚",
                    English = "Bind",
                    French = "Entrave",
                    German = "Fessel",
                    Japanese = "バインド"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(14, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "加重",
                    English = "Heavy",
                    French = "Pesanteur",
                    German = "Gewicht",
                    Japanese = "ヘヴィ"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(15, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "失明",
                    English = "Blind",
                    French = "Cécité",
                    German = "Blind",
                    Japanese = "暗闇"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(17, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "麻痹",
                    English = "Paralysis",
                    French = "Paralysie",
                    German = "Paralyse",
                    Japanese = "麻痺"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(18, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "中毒",
                    English = "Poison",
                    French = "Poison",
                    German = "Gift",
                    Japanese = "毒"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(19, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "猛毒",
                    English = "Pollen",
                    French = "Poison violent",
                    German = "Giftpollen",
                    Japanese = "猛毒"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(20, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "TP Bleed",
                    English = "TP Bleed",
                    French = "Saignée de PT",
                    German = "TP-Verlust",
                    Japanese = "ＴＰ継続ダメージ"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(21, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "最大体力增加",
                    English = "HP Boost",
                    French = "Bonus de PV",
                    German = "LP-Bonus",
                    Japanese = "最大ＨＰアップ"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(22, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "最大体力减少",
                    English = "HP Penalty",
                    French = "Malus de PV",
                    German = "LP-Malus",
                    Japanese = "最大ＨＰダウン"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(23, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "最大魔力增加",
                    English = "MP Boost",
                    French = "Bonus de PM",
                    German = "MP-Bonus",
                    Japanese = "最大ＭＰアップ"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(24, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "最大魔力减少",
                    English = "MP Penalty",
                    French = "Malus de PM",
                    German = "MP-Malus",
                    Japanese = "最大ＭＰダウン"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(25, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "物理攻击力提高",
                    English = "Attack Up",
                    French = "Bonus d'attaque",
                    German = "Attacke-Bonus",
                    Japanese = "物理攻撃力アップ"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(26, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "物理攻击力降低",
                    English = "Attack Down",
                    French = "Malus d'attaque",
                    German = "Attacke-Malus",
                    Japanese = "物理攻撃力ダウン"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(27, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "命中力增加",
                    English = "Accuracy Up",
                    French = "Bonus de précision",
                    German = "Präzisions-Bonus",
                    Japanese = "命中率アップ"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(28, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "命中力下降",
                    English = "Accuracy Down",
                    French = "Malus de précision",
                    German = "Präzisions-Malus",
                    Japanese = "命中率ダウン"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(29, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "物理防御力提高",
                    English = "Defense Up",
                    French = "Bonus de défense",
                    German = "Verteidigungs-Bonus",
                    Japanese = "物理防御力アップ"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(30, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "物理防御力下降",
                    English = "Defense Down",
                    French = "Malus de défense",
                    German = "Verteidigungs-Malus",
                    Japanese = "物理防御力ダウン"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(31, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "回避力提高",
                    English = "Evasion Up",
                    French = "Bonus d'esquive",
                    German = "Ausweich-Bonus",
                    Japanese = "回避力アップ"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(32, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "回避力降低",
                    English = "Evasion Down",
                    French = "Malus d'esquive",
                    German = "Ausweich-Malus",
                    Japanese = "回避力ダウン"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(33, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "魔法攻击力增加",
                    English = "Attack Magic Potency Up",
                    French = "Bonus de puissance magique",
                    German = "Offensivmagie-Bonus",
                    Japanese = "魔法攻撃力アップ"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(34, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "魔法攻击力降低",
                    English = "Attack Magic Potency Down",
                    French = "Malus de puissance magique",
                    German = "Offensivmagie-Malus",
                    Japanese = "魔法攻撃力ダウン"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(35, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "魔法恢复力增加",
                    English = "Healing Potency Up",
                    French = "Bonus de magie curative",
                    German = "Heilmagie-Bonus",
                    Japanese = "魔法回復力アップ"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(36, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Healing Potency Down",
                    English = "Healing Potency Down",
                    French = "Malus de magie curative",
                    German = "Heilmagie-Malus",
                    Japanese = "魔法回復力ダウン"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(37, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "魔法防御力上升",
                    English = "Magic Defense Up",
                    French = "Bonus de défense magique",
                    German = "Magieabwehr-Bonus",
                    Japanese = "魔法防御力アップ"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(38, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "魔法防御力下降",
                    English = "Magic Defense Down",
                    French = "Malus de défense magique",
                    German = "Magieabwehr-Malus",
                    Japanese = "魔法防御力ダウン"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(39, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "眩晕抗性",
                    English = "Stun Resistance",
                    French = "Résistance à Étourdissement",
                    German = "Betäubungsresistenz",
                    Japanese = "スタン無効"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(40, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "沉默抗性",
                    English = "Silence Resistance",
                    French = "Résistance à Silence",
                    German = "Stumm-Resistenz",
                    Japanese = "沈黙無効"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(41, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "制作设备",
                    English = "Crafting Facility",
                    French = "Installation d'artisanat",
                    German = "Werkstattstimmung",
                    Japanese = "製作設備"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(42, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "超越之力",
                    English = "The Echo",
                    French = "L'Écho",
                    German = "Kraft des Transzendierens",
                    Japanese = "超える力"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(43, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "衰弱",
                    English = "Weakness",
                    French = "Affaiblissement",
                    German = "Schwäche",
                    Japanese = "衰弱"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(44, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Brink of Death",
                    English = "Brink of Death",
                    French = "Mourant",
                    German = "Sterbenselend",
                    Japanese = "衰弱［強］"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(45, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Crafter's Grace",
                    English = "Crafter's Grace",
                    French = "Grâce de l'artisan",
                    German = "Sternstunde der Handwerker",
                    Japanese = "経験値アップ（クラフター専用）"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(46, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Gatherer's Grace",
                    English = "Gatherer's Grace",
                    French = "Grâce du récolteur",
                    German = "Sternstunde der Sammler",
                    Japanese = "経験値アップ（ギャザラー専用）"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(47, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Stealth",
                    English = "Stealth",
                    French = "Furtivité",
                    German = "Coeurl-Pfoten",
                    Japanese = "ステルス"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(48, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "用食",
                    English = "Well Fed",
                    French = "Repu",
                    German = "Gut gesättigt",
                    Japanese = "食事"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(49, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "强化药",
                    English = "Medicated",
                    French = "Médicamenté",
                    German = "Stärkung",
                    Japanese = "強化薬"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(50, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Sprint",
                    English = "Sprint",
                    French = "Sprint",
                    German = "Sprint",
                    Japanese = "スプリント"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(51, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "力量下降",
                    English = "Strength Down",
                    French = "Malus de force",
                    German = "Stärke-Malus",
                    Japanese = "ＳＴＲダウン"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(52, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Vitality Down",
                    English = "Vitality Down",
                    French = "Malus de vitalité",
                    German = "Konstitutions-Malus",
                    Japanese = "ＶＩＴダウン"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(53, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Physical Damage Up",
                    English = "Physical Damage Up",
                    French = "Bonus de dégâts physiques",
                    German = "Schadenswert +",
                    Japanese = "物理ダメージ上昇"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(54, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Physical Damage Down",
                    English = "Physical Damage Down",
                    French = "Malus de dégâts physiques",
                    German = "Schadenswert -",
                    Japanese = "物理ダメージ低下"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(55, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Physical Vulnerability Down",
                    English = "Physical Vulnerability Down",
                    French = "Vulnérabilité physique diminuée",
                    German = "Verringerte physische Verwundbarkeit",
                    Japanese = "被物理ダメージ軽減"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(56, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Physical Vulnerability Up",
                    English = "Physical Vulnerability Up",
                    French = "Vulnérabilité physique augmentée",
                    German = "Erhöhte physische Verwundbarkeit",
                    Japanese = "被物理ダメージ増加"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(57, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "魔法伤害上升",
                    English = "Magic Damage Up",
                    French = "Bonus de dégâts magiques",
                    German = "Magieschaden +",
                    Japanese = "魔法ダメージ上昇"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(58, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "魔法伤害下降",
                    English = "Magic Damage Down",
                    French = "Malus de dégâts magiques",
                    German = "Magieschaden -",
                    Japanese = "魔法ダメージ低下"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(59, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Magic Vulnerability Down",
                    English = "Magic Vulnerability Down",
                    French = "Vulnérabilité magique diminuée",
                    German = "Verringerte Magie-Verwundbarkeit",
                    Japanese = "被魔法ダメージ軽減"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(60, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Magic Vulnerability Up",
                    English = "Magic Vulnerability Up",
                    French = "Vulnérabilité magique augmentée",
                    German = "Erhöhte Magie-Verwundbarkeit",
                    Japanese = "被魔法ダメージ増加"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(61, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Damage Up",
                    English = "Damage Up",
                    French = "Bonus de dégâts",
                    German = "Schaden +",
                    Japanese = "ダメージ上昇"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(62, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Damage Down",
                    English = "Damage Down",
                    French = "Malus de dégâts",
                    German = "Schaden -",
                    Japanese = "ダメージ低下"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(63, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Vulnerability Down",
                    English = "Vulnerability Down",
                    French = "Vulnérabilité diminuée",
                    German = "Verringerte Verwundbarkeit",
                    Japanese = "被ダメージ低下"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(64, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "受到的伤害提升",
                    English = "Vulnerability Up",
                    French = "Vulnérabilité augmentée",
                    German = "Erhöhte Verwundbarkeit",
                    Japanese = "被ダメージ上昇"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(65, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Critical Skill",
                    English = "Critical Skill",
                    French = "Maîtrise critique",
                    German = "Kritisches Potenzial",
                    Japanese = "ウェポンスキル強化：クリティカル"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(66, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "恐怖",
                    English = "Terror",
                    French = "Terreur",
                    German = "Terror",
                    Japanese = "恐怖"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(67, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Leaden",
                    English = "Leaden",
                    French = "Plombé",
                    German = "Bleischwere",
                    Japanese = "ヘヴィ[強]"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(68, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Drainstrikes",
                    English = "Drainstrikes",
                    French = "Coups drainants",
                    German = "Auszehren",
                    Japanese = "オートアタック強化：ＨＰ吸収"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(69, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Aspirstrikes",
                    English = "Aspirstrikes",
                    French = "Coups aspirants",
                    German = "Auslaugen",
                    Japanese = "オートアタック強化：ＴＰ吸収"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(70, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Stunstrikes",
                    English = "Stunstrikes",
                    French = "Coups étourdissants",
                    German = "Ausschalten",
                    Japanese = "オートアタック強化：スタン"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(71, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Rampart",
                    English = "Rampart",
                    French = "Rempart",
                    German = "Schutzwall",
                    Japanese = "ランパート"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(72, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Convalescence",
                    English = "Convalescence",
                    French = "Convalescence",
                    German = "Konvaleszenz",
                    Japanese = "コンバレセンス"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(73, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Awareness",
                    English = "Awareness",
                    French = "Diligence",
                    German = "Achtsamkeit",
                    Japanese = "アウェアネス"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(74, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Sentinel",
                    English = "Sentinel",
                    French = "Sentinelle",
                    German = "Sentinel",
                    Japanese = "センチネル"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(75, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "钢之意志",
                    English = "Tempered Will",
                    French = "Volonté d'acier",
                    German = "Eherner Wille",
                    Japanese = "鋼の意志"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(76, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Fight or Flight",
                    English = "Fight or Flight",
                    French = "Combat acharné",
                    German = "Verwegenheit",
                    Japanese = "ファイト・オア・フライト"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(77, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Bulwark",
                    English = "Bulwark",
                    French = "Forteresse",
                    German = "Bollwerk",
                    Japanese = "ブルワーク"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(78, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "忠义之剑",
                    English = "Sword Oath",
                    French = "Serment de l'épée",
                    German = "Schwert-Eid",
                    Japanese = "忠義の剣"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(79, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "忠义之盾",
                    English = "Shield Oath",
                    French = "Serment du bouclier",
                    German = "Schild-Eid",
                    Japanese = "忠義の盾"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(80, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Cover",
                    English = "Cover",
                    French = "Couverture",
                    German = "Deckung",
                    Japanese = "かばう"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(81, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Covered",
                    English = "Covered",
                    French = "Couvert",
                    German = "Gedeckt",
                    Japanese = "被かばう"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(82, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Hallowed Ground",
                    English = "Hallowed Ground",
                    French = "Invincible",
                    German = "Heiliger Boden",
                    Japanese = "インビンシブル"
                },
                CompanyAction = true,
            });
            StatusEffects.Add(83, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Foresight",
                    English = "Foresight",
                    French = "Aguet",
                    German = "Vorahnung",
                    Japanese = "フォーサイト"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(84, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Bloodbath",
                    English = "Bloodbath",
                    French = "Bain de sang",
                    German = "Blutbad",
                    Japanese = "ブラッドバス"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(85, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Maim",
                    English = "Maim",
                    French = "Mutilation",
                    German = "Verstümmelung",
                    Japanese = "メイム"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(86, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Berserk",
                    English = "Berserk",
                    French = "Berserk",
                    German = "Tollwut",
                    Japanese = "バーサク"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(87, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Thrill of Battle",
                    English = "Thrill of Battle",
                    French = "Frisson de la bataille",
                    German = "Kampfrausch",
                    Japanese = "スリル・オブ・バトル"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(88, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Holmgang",
                    English = "Holmgang",
                    French = "Holmgang",
                    German = "Holmgang",
                    Japanese = "ホルムギャング"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(89, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Vengeance",
                    English = "Vengeance",
                    French = "Représailles",
                    German = "Rache",
                    Japanese = "ヴェンジェンス"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(90, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Storm's Eye",
                    English = "Storm's Eye",
                    French = "Œil de la tempête",
                    German = "Sturmbrecher",
                    Japanese = "シュトルムブレハ"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(91, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Defiance",
                    English = "Defiance",
                    French = "Défi",
                    German = "Verteidiger",
                    Japanese = "ディフェンダー"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(92, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Unchained",
                    English = "Unchained",
                    French = "Affranchissement",
                    German = "Entfesselt",
                    Japanese = "アンチェインド"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(93, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Wrath",
                    English = "Wrath",
                    French = "Rage",
                    German = "Zorn",
                    Japanese = "ラース"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(94, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Wrath II",
                    English = "Wrath II",
                    French = "Rage II",
                    German = "Zorn II",
                    Japanese = "ラースII"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(95, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Wrath III",
                    English = "Wrath III",
                    French = "Rage III",
                    German = "Zorn III",
                    Japanese = "ラースIII"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(96, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Wrath IV",
                    English = "Wrath IV",
                    French = "Rage IV",
                    German = "Zorn IV",
                    Japanese = "ラースIV"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(97, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Infuriated",
                    English = "Infuriated",
                    French = "Rage V",
                    German = "Zorn V",
                    Japanese = "ラースV"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(98, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "双龙脚",
                    English = "Dragon Kick",
                    French = "Tacle du dragon",
                    German = "Drachentritt",
                    Japanese = "双竜脚"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(99, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "飘羽步",
                    English = "Featherfoot",
                    French = "Pieds légers",
                    German = "Leichtfuß",
                    Japanese = "フェザーステップ"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(100, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "发劲",
                    English = "Internal Release",
                    French = "Relâchement intérieur",
                    German = "Innere Gelöstheit",
                    Japanese = "発勁"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(101, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "双掌打",
                    English = "Twin Snakes",
                    French = "Serpents jumeaux",
                    German = "Doppelviper",
                    Japanese = "双掌打"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(102, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "真言",
                    English = "Mantra",
                    French = "Mantra",
                    German = "Mantra",
                    Japanese = "マントラ"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(103, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "红莲体势",
                    English = "Fists of Fire",
                    French = "Poings de feu",
                    German = "Sengende Aura",
                    Japanese = "紅蓮の構え"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(104, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "金刚体势",
                    English = "Fists of Earth",
                    French = "Poings de terre",
                    German = "Steinerne Aura",
                    Japanese = "金剛の構え"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(105, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "疾风体势",
                    English = "Fists of Wind",
                    French = "Poings de vent",
                    German = "Beflügelnde Aura",
                    Japanese = "疾風の構え"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(106, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "秘孔拳",
                    English = "Touch of Death",
                    French = "Toucher mortel",
                    German = "Hauch des Todes",
                    Japanese = "秘孔拳"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(107, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "魔猿身形",
                    English = "Opo-opo Form",
                    French = "Posture de l'opo-opo",
                    German = "Opo-Opo-Form",
                    Japanese = "壱の型：魔猿"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(108, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Raptor Form",
                    English = "Raptor Form",
                    French = "Posture du raptor",
                    German = "Raptor-Form",
                    Japanese = "弐の型：走竜"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(109, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Coeurl Form",
                    English = "Coeurl Form",
                    French = "Posture du coeurl",
                    German = "Coeurl-Form",
                    Japanese = "参の型：猛虎"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(110, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Perfect Balance",
                    English = "Perfect Balance",
                    French = "Équilibre parfait",
                    German = "Improvisation",
                    Japanese = "踏鳴"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(111, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "疾风迅雷",
                    English = "Greased Lightning",
                    French = "Vitesse de l'éclair",
                    German = "Geölter Blitz",
                    Japanese = "疾風迅雷"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(112, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "疾风迅雷 II",
                    English = "Greased Lightning II",
                    French = "Vitesse de l'éclair II",
                    German = "Geölter Blitz II",
                    Japanese = "疾風迅雷II"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(113, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "疾风迅雷 III",
                    English = "Greased Lightning III",
                    French = "Vitesse de l'éclair III",
                    German = "Geölter Blitz III",
                    Japanese = "疾風迅雷III"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(114, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Keen Flurry",
                    English = "Keen Flurry",
                    French = "Volée défensive",
                    German = "Auge des Sturms",
                    Japanese = "キーンフラーリ"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(115, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Heavy Thrust",
                    English = "Heavy Thrust",
                    French = "Percée puissante",
                    German = "Gewaltiger Stoß",
                    Japanese = "ヘヴィスラスト"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(116, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Life Surge",
                    English = "Life Surge",
                    French = "Souffle de vie",
                    German = "Vitalwallung",
                    Japanese = "ライフサージ"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(117, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "舍身",
                    English = "Blood for Blood",
                    French = "Du sang pour du sang",
                    German = "Zahn um Zahn",
                    Japanese = "捨身"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(118, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "樱花怒放",
                    English = "Chaos Thrust",
                    French = "Percée chaotique",
                    German = "Chaotischer Tjost",
                    Japanese = "桜華狂咲"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(119, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "二段突刺",
                    English = "Phlebotomize",
                    French = "Double percée",
                    German = "Phlebotomie",
                    Japanese = "二段突き"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(120, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Power Surge",
                    English = "Power Surge",
                    French = "Souffle de puissance",
                    German = "Drachenklaue",
                    Japanese = "竜槍"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(121, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Disembowel",
                    English = "Disembowel",
                    French = "Éventration",
                    German = "Drachengriff",
                    Japanese = "ディセムボウル"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(122, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Straighter Shot",
                    English = "Straighter Shot",
                    French = "Tir à l'arc surpuissant",
                    German = "Direkter Schuss +",
                    Japanese = "ストレートショット効果アップ"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(123, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "鹰眼",
                    English = "Hawk's Eye",
                    French = "Œil de faucon",
                    German = "Falkenauge",
                    Japanese = "ホークアイ"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(124, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "毒咬箭",
                    English = "Venomous Bite",
                    French = "Morsure venimeuse",
                    German = "Infizierte Wunde",
                    Japanese = "ベノムバイト"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(125, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "猛者强击",
                    English = "Raging Strikes",
                    French = "Tir furieux",
                    German = "Wütende Attacke",
                    Japanese = "猛者の撃"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(126, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Physical Vulnerability Up",
                    English = "Physical Vulnerability Up",
                    French = "Vulnérabilité physique augmentée",
                    German = "Erhöhte physische Verwundbarkeit",
                    Japanese = "被物理ダメージ増加"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(127, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "静者强击",
                    English = "Quelling Strikes",
                    French = "Frappe silencieuse",
                    German = "Heimliche Attacke",
                    Japanese = "静者の撃"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(128, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "纷乱箭",
                    English = "Barrage",
                    French = "Rafale de coups",
                    German = "Sperrfeuer",
                    Japanese = "乱れ撃ち"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(129, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "风蚀箭",
                    English = "Windbite",
                    French = "Morsure du vent",
                    German = "Beißender Wind",
                    Japanese = "ウィンドバイト"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(130, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "直线射击",
                    English = "Straight Shot",
                    French = "Tir droit",
                    German = "Direkter Schuss",
                    Japanese = "ストレートショット"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(131, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Downpour of Death",
                    English = "Downpour of Death",
                    French = "Déluge mortel",
                    German = "Tödlicher Regen +",
                    Japanese = "レイン・オブ・デス効果アップ"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(132, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Quicker Nock",
                    English = "Quicker Nock",
                    French = "Salve fulgurante améliorée",
                    German = "Pfeilsalve +",
                    Japanese = "クイックノック効果アップ"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(133, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Swiftsong",
                    English = "Swiftsong",
                    French = "Chant rapide",
                    German = "Schmissiger Song",
                    Japanese = "スウィフトソング"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(134, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Swiftsong",
                    English = "Swiftsong",
                    French = "Chant rapide",
                    German = "Schmissiger Song",
                    Japanese = "スウィフトソング：効果"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(135, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Mage's Ballad",
                    English = "Mage's Ballad",
                    French = "Ballade du mage",
                    German = "Ballade des Weisen",
                    Japanese = "賢人のバラード"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(136, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Mage's Ballad",
                    English = "Mage's Ballad",
                    French = "Ballade du mage",
                    German = "Ballade des Weisen",
                    Japanese = "賢人のバラード：効果"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(137, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Army's Paeon",
                    English = "Army's Paeon",
                    French = "Péan martial",
                    German = "Hymne der Krieger",
                    Japanese = "軍神のパイオン"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(138, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Army's Paeon",
                    English = "Army's Paeon",
                    French = "Péan martial",
                    German = "Hymne der Krieger",
                    Japanese = "軍神のパイオン：効果"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(139, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Foe Requiem",
                    English = "Foe Requiem",
                    French = "Requiem ennemi",
                    German = "Requiem der Feinde",
                    Japanese = "魔人のレクイエム"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(140, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Foe Requiem",
                    English = "Foe Requiem",
                    French = "Requiem ennemi",
                    German = "Requiem der Feinde",
                    Japanese = "魔人のレクイエム：効果"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(141, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Battle Voice",
                    English = "Battle Voice",
                    French = "Voix de combat",
                    German = "Ode an die Seele",
                    Japanese = "バトルボイス"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(142, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Chameleon",
                    English = "Chameleon",
                    French = "Caméléon",
                    German = "Chamäleon",
                    Japanese = "カメレオン"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(143, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "疾风",
                    English = "Aero",
                    French = "Vent",
                    German = "Wind",
                    Japanese = "エアロ"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(144, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "烈风",
                    English = "Aero II",
                    French = "Extra Vent",
                    German = "Windra",
                    Japanese = "エアロラ"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(145, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "站姿",
                    English = "Cleric Stance",
                    French = "Prestance du prêtre",
                    German = "Bußprediger",
                    Japanese = "クルセードスタンス"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(146, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Protect",
                    English = "Protect",
                    French = "Bouclier",
                    German = "Protes",
                    Japanese = "プロテス"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(147, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Protect",
                    English = "Protect",
                    French = "Bouclier",
                    German = "Protes",
                    Japanese = "プロテス"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(148, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Raise",
                    English = "Raise",
                    French = "Vie",
                    German = "Wiederbeleben",
                    Japanese = "蘇生"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(149, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Stun",
                    English = "Stun",
                    French = "Étourdissement",
                    German = "Betäubung",
                    Japanese = "スタン"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(150, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Medica II",
                    English = "Medica II",
                    French = "Extra Médica",
                    German = "Resedra",
                    Japanese = "メディカラ"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(151, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Stoneskin",
                    English = "Stoneskin",
                    French = "Cuirasse",
                    German = "Steinhaut",
                    Japanese = "ストンスキン"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(152, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Stoneskin (Physical)",
                    English = "Stoneskin (Physical)",
                    French = "Cuirasse (physique)",
                    German = "Steinhaut (physisch)",
                    Japanese = "ストンスキン（物理攻撃）"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(153, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Stoneskin (Magical)",
                    English = "Stoneskin (Magical)",
                    French = "Cuirasse (magique)",
                    German = "Steinhaut (magisch)",
                    Japanese = "ストンスキン（魔法攻撃）"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(154, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Shroud of Saints",
                    English = "Shroud of Saints",
                    French = "Voile des saints",
                    German = "Fispelstimme",
                    Japanese = "女神の加護"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(155, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Freecure",
                    English = "Freecure",
                    French = "Extra Soin amélioré",
                    German = "Vitra +",
                    Japanese = "ケアルラ効果アップ"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(156, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Overcure",
                    English = "Overcure",
                    French = "Méga Soin amélioré",
                    German = "Vitaga +",
                    Japanese = "ケアルガ効果アップ"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(157, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Presence of Mind",
                    English = "Presence of Mind",
                    French = "Présence d'esprit",
                    German = "Geistesgegenwart",
                    Japanese = "神速魔"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(158, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Regen",
                    English = "Regen",
                    French = "Récup",
                    German = "Regena",
                    Japanese = "リジェネ"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(159, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Divine Seal",
                    English = "Divine Seal",
                    French = "Sceau divin",
                    German = "Göttliches Siegel",
                    Japanese = "ディヴァインシール"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(160, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Surecast",
                    English = "Surecast",
                    French = "Stoïcisme",
                    German = "Unbeirrbarkeit",
                    Japanese = "堅実魔"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(161, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "闪雷",
                    English = "Thunder",
                    French = "Foudre",
                    German = "Blitz",
                    Japanese = "サンダー"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(162, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "震雷",
                    English = "Thunder II",
                    French = "Extra Foudre",
                    German = "Blitzra",
                    Japanese = "サンダラ"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(163, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "暴雷",
                    English = "Thunder III",
                    French = "Méga Foudre",
                    German = "Blitzga",
                    Japanese = "サンダガ"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(164, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Thundercloud",
                    English = "Thundercloud",
                    French = "Nuage d'orage",
                    German = "Blitz +",
                    Japanese = "サンダー系魔法効果アップ"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(165, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Firestarter",
                    English = "Firestarter",
                    French = "Pyromane",
                    German = "Feuga +",
                    Japanese = "ファイガ効果アップ"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(166, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Succor",
                    English = "Succor",
                    French = "Dogme de survie",
                    German = "Kurieren +",
                    Japanese = "士気高揚の策効果アップ"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(167, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Swiftcast",
                    English = "Swiftcast",
                    French = "Magie prompte",
                    German = "Spontaneität",
                    Japanese = "迅速魔"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(168, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Manaward",
                    English = "Manaward",
                    French = "Barrière de mana",
                    German = "Mana-Schild",
                    Japanese = "マバリア"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(169, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Manawall",
                    English = "Manawall",
                    French = "Mur de mana",
                    German = "Mana-Wand",
                    Japanese = "ウォール"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(170, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Apocatastasis",
                    English = "Apocatastasis",
                    French = "Apocatastase",
                    German = "Apokatastasis",
                    Japanese = "アポカタスタシス"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(171, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Ekpyrosis",
                    English = "Ekpyrosis",
                    French = "Ekpyrosis",
                    German = "Ekpyrosis",
                    Japanese = "アポカタスタシス不可"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(172, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Infirmity",
                    English = "Infirmity",
                    French = "Infirmité",
                    German = "Gebrechlichkeit",
                    Japanese = "虚弱"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(173, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Astral Fire",
                    English = "Astral Fire",
                    French = "Feu astral",
                    German = "Lichtfeuer",
                    Japanese = "アストラルファイア"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(174, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Astral Fire II",
                    English = "Astral Fire II",
                    French = "Feu astral II",
                    German = "Lichtfeuer II",
                    Japanese = "アストラルファイアII"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(175, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Astral Fire III",
                    English = "Astral Fire III",
                    French = "Feu astral III",
                    German = "Lichtfeuer III",
                    Japanese = "アストラルファイアIII"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(176, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Umbral Ice",
                    English = "Umbral Ice",
                    French = "Glace ombrale",
                    German = "Schatteneis",
                    Japanese = "アンブラルブリザード"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(177, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Umbral Ice II",
                    English = "Umbral Ice II",
                    French = "Glace ombrale II",
                    German = "Schatteneis II",
                    Japanese = "アンブラルブリザードII"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(178, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Umbral Ice III",
                    English = "Umbral Ice III",
                    French = "Glace ombrale III",
                    German = "Schatteneis III",
                    Japanese = "アンブラルブリザードIII"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(179, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "毒菌",
                    English = "Bio",
                    French = "Bactérie",
                    German = "Bio",
                    Japanese = "バイオ"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(180, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "瘴气",
                    English = "Miasma",
                    French = "Miasmes",
                    German = "Miasma",
                    Japanese = "ミアズマ"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(181, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "病弱",
                    English = "Disease",
                    French = "Maladie",
                    German = "Krankheit",
                    Japanese = "病気"
                },
                CompanyAction = true,
            });
            StatusEffects.Add(182, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "病毒",
                    English = "Virus",
                    French = "Virus",
                    German = "Virus",
                    Japanese = "ウイルス"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(183, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Fever",
                    English = "Fever",
                    French = "Virus de l'esprit",
                    German = "Geistesvirus",
                    Japanese = "マインドウイルス"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(184, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Sustain",
                    English = "Sustain",
                    French = "Transfusion",
                    German = "Erhaltung",
                    Japanese = "サステイン"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(185, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Eye for an Eye",
                    English = "Eye for an Eye",
                    French = "Garde-corps",
                    German = "Auge um Auge",
                    Japanese = "アイ・フォー・アイ"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(186, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Eye for an Eye",
                    English = "Eye for an Eye",
                    French = "Garde-corps",
                    German = "Auge um Auge",
                    Japanese = "アイ・フォー・アイ：効果"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(187, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Rouse",
                    English = "Rouse",
                    French = "Stimulation",
                    German = "Aufmuntern",
                    Japanese = "ラウズ"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(188, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "瘴疠",
                    English = "Miasma II",
                    French = "Extra Miasmes",
                    German = "Miasra",
                    Japanese = "ミアズラ"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(189, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "猛毒菌",
                    English = "Bio II",
                    French = "Extra Bactérie",
                    German = "Biora",
                    Japanese = "バイオラ"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(190, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Shadow Flare",
                    English = "Shadow Flare",
                    French = "Éruption ténébreuse",
                    German = "Schattenflamme",
                    Japanese = "シャドウフレア"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(192, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "鼓舞",
                    English = "Spur",
                    French = "Encouragement",
                    German = "Ansporn",
                    Japanese = "スパー"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(193, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "减速",
                    English = "Slow",
                    French = "Lenteur",
                    German = "Gemach",
                    Japanese = "スロウ"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(194, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Shield Wall",
                    English = "Shield Wall",
                    French = "Mur protecteur",
                    German = "Schutzschild",
                    Japanese = "シールドウォール"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(195, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Mighty Guard",
                    English = "Mighty Guard",
                    French = "Garde puissante",
                    German = "Totalabwehr",
                    Japanese = "マイティガード"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(196, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Last Bastion",
                    English = "Last Bastion",
                    French = "Dernier bastion",
                    German = "Letzte Bastion",
                    Japanese = "ラストバスティオン"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(197, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Blaze Spikes",
                    English = "Blaze Spikes",
                    French = "Pointes de feu",
                    German = "Feuerstachel",
                    Japanese = "ブレイズスパイク"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(198, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Ice Spikes",
                    English = "Ice Spikes",
                    French = "Pointes de glace",
                    German = "Eisstachel",
                    Japanese = "アイススパイク"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(199, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Shock Spikes",
                    English = "Shock Spikes",
                    French = "Pointes de foudre",
                    German = "Schockstachel",
                    Japanese = "ショックスパイク"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(200, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Physical Vulnerability Up",
                    English = "Physical Vulnerability Up",
                    French = "Vulnérabilité physique augmentée",
                    German = "Erhöhte physische Verwundbarkeit",
                    Japanese = "被物理ダメージ増加"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(201, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Stun",
                    English = "Stun",
                    French = "Étourdissement",
                    German = "Betäubung",
                    Japanese = "スタン"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(202, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Vulnerability Up",
                    English = "Vulnerability Up",
                    French = "Vulnérabilité augmentée",
                    German = "Erhöhte Verwundbarkeit",
                    Japanese = "被ダメージ上昇"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(203, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Boost",
                    English = "Boost",
                    French = "Accumulation",
                    German = "Akkumulation",
                    Japanese = "力溜め"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(204, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Enfire",
                    English = "Enfire",
                    French = "EndoFeu",
                    German = "Runenwaffe: Feuer",
                    Japanese = "魔法剣・火"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(205, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Enblizzard",
                    English = "Enblizzard",
                    French = "EndoGlace",
                    German = "Runenwaffe: Eis",
                    Japanese = "魔法剣・氷"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(206, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Enaero",
                    English = "Enaero",
                    French = "EndoVent",
                    German = "Runenwaffe: Wind",
                    Japanese = "魔法剣・風"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(207, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Enstone",
                    English = "Enstone",
                    French = "EndoPierre",
                    German = "Runenwaffe: Erde",
                    Japanese = "魔法剣・土"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(208, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Enthunder",
                    English = "Enthunder",
                    French = "EndoFoudre",
                    German = "Runenwaffe: Blitz",
                    Japanese = "魔法剣・雷"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(209, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Enwater",
                    English = "Enwater",
                    French = "EndoEau",
                    German = "Runenwaffe: Wasser",
                    Japanese = "魔法剣・水"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(210, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Doom",
                    English = "Doom",
                    French = "Glas",
                    German = "Todesurteil",
                    Japanese = "死の宣告"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(211, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Sharpened Knife",
                    English = "Sharpened Knife",
                    French = "Couteau aiguisé",
                    German = "Gewetztes Messer",
                    Japanese = "研がれた包丁"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(212, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "True Sight",
                    English = "True Sight",
                    French = "Vision véritable",
                    German = "Wahre Gestalt",
                    Japanese = "見破り"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(213, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "怀柔状态",
                    English = "Pacification",
                    French = "Tranquillisation",
                    German = "Besänftigung",
                    Japanese = "懐柔状態"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(214, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Agitation",
                    English = "Agitation",
                    French = "Énervement",
                    German = "Aufstachelung",
                    Japanese = "懐柔失敗"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(215, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Damage Down",
                    English = "Damage Down",
                    French = "Malus de dégâts",
                    German = "Schaden -",
                    Japanese = "ダメージ低下"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(216, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "麻痹",
                    English = "Paralysis",
                    French = "Paralysie",
                    German = "Paralyse",
                    Japanese = "麻痺"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(217, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "三角测量",
                    English = "Triangulate",
                    French = "Forestier",
                    German = "Geodäsie",
                    Japanese = "トライアングレート"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(218, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "采集获得率提升",
                    English = "Gathering Rate Up",
                    French = "Récolte améliorée",
                    German = "Sammelrate erhöht",
                    Japanese = "採集獲得率アップ"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(219, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "采集获得数增加",
                    English = "Gathering Yield Up",
                    French = "Récolte abondante",
                    German = "Sammelgewinn erhöht",
                    Japanese = "採集獲得数アップ"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(220, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Gathering Fortune Up",
                    English = "Gathering Fortune Up",
                    French = "Récolte de qualité",
                    German = "Sammelglück erhöht",
                    Japanese = "採集HQ獲得率アップ"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(221, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Truth of Forests",
                    English = "Truth of Forests",
                    French = "Science des végétaux",
                    German = "Flurenthüllung",
                    Japanese = "トゥルー・オブ・フォレスト"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(222, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Truth of Mountains",
                    English = "Truth of Mountains",
                    French = "Science des minéraux",
                    German = "Tellurische Enthüllung",
                    Japanese = "トゥルー・オブ・ミネラル"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(223, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Byregot's Ward",
                    English = "Byregot's Ward",
                    French = "Grâce de Byregot",
                    German = "Byregots Segen",
                    Japanese = "ビエルゴの加護"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(224, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "诺菲卡的加护",
                    English = "Nophica's Ward",
                    French = "Grâce de Nophica",
                    German = "Nophicas Segen",
                    Japanese = "ノフィカの加護"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(225, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Prospect",
                    English = "Prospect",
                    French = "Prospecteur",
                    German = "Prospektion",
                    Japanese = "プロスペクト"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(226, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "加速",
                    English = "Haste",
                    French = "Hâte",
                    German = "Hast",
                    Japanese = "ヘイスト"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(227, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Seduced",
                    English = "Seduced",
                    French = "Séduction",
                    German = "Versuchung",
                    Japanese = "誘惑"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(228, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Menphina's Ward",
                    English = "Menphina's Ward",
                    French = "Grâce de Menphina",
                    German = "Menphinas Segen",
                    Japanese = "メネフィナの加護"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(229, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Nald'thal's Ward",
                    English = "Nald'thal's Ward",
                    French = "Grâce de Nald'thal",
                    German = "Nald'thals Segen",
                    Japanese = "ナルザルの加護"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(230, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Llymlaen's Ward",
                    English = "Llymlaen's Ward",
                    French = "Grâce de Llymlaen",
                    German = "Llymlaens Segen",
                    Japanese = "リムレーンの加護"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(231, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Thaliak's Ward",
                    English = "Thaliak's Ward",
                    French = "Grâce de Thaliak",
                    German = "Thaliaks Segen",
                    Japanese = "サリャクの加護"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(232, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Preparation",
                    English = "Preparation",
                    French = "Préparation",
                    German = "Vorausplanung",
                    Japanese = "プレパレーション"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(233, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Arbor Call",
                    English = "Arbor Call",
                    French = "Dendrologie",
                    German = "Ruf des Waldes",
                    Japanese = "アーバーコール"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(234, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Lay of the Land",
                    English = "Lay of the Land",
                    French = "Géologie",
                    German = "Bodenbefund",
                    Japanese = "ランドサーベイ"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(235, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Windburn",
                    English = "Windburn",
                    French = "Brûlure du vent",
                    German = "Beißender Wind",
                    Japanese = "裂傷"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(236, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "陆行鸟猛啄",
                    English = "Choco Beak",
                    French = "Choco-bec",
                    German = "Chocobo-Schnabel",
                    Japanese = "チョコビーク"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(237, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "陆行鸟再生",
                    English = "Choco Regen",
                    French = "Choco-récup",
                    German = "Chocobo-Regena",
                    Japanese = "チョコリジェネ"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(238, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Choco Surge",
                    English = "Choco Surge",
                    French = "Choco-ardeur",
                    German = "Chocobo-Quelle",
                    Japanese = "チョコサージ"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(239, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "The Echo",
                    English = "The Echo",
                    French = "L'Écho",
                    German = "Kraft des Transzendierens",
                    Japanese = "超える力"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(240, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Heavy",
                    English = "Heavy",
                    French = "Pesanteur",
                    German = "Gewicht",
                    Japanese = "ヘヴィ"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(241, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Blessing of Light",
                    English = "Blessing of Light",
                    French = "Bénédiction de la Lumière",
                    German = "Gnade des Lichts",
                    Japanese = "光の加護"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(242, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Arbor Call II",
                    English = "Arbor Call II",
                    French = "Dendrologie II",
                    German = "Ruf des Waldes II",
                    Japanese = "アーバーコールII"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(243, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Lay of the Land II",
                    English = "Lay of the Land II",
                    French = "Géologie II",
                    German = "Bodenbefund II",
                    Japanese = "ランドサーベイII"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(244, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "碎骨打",
                    English = "Fracture",
                    French = "Fracture",
                    German = "Knochenbrecher",
                    Japanese = "フラクチャー"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(245, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Sanction",
                    English = "Sanction",
                    French = "Sanction",
                    German = "Ermächtigung",
                    Japanese = "サンクション"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(246, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "破碎拳",
                    English = "Demolish",
                    French = "Démolition",
                    German = "Demolieren",
                    Japanese = "破砕拳"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(247, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Rain of Death",
                    English = "Rain of Death",
                    French = "Pluie mortelle",
                    German = "Tödlicher Regen",
                    Japanese = "レイン・オブ・デス"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(248, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "厄运流转",
                    English = "Circle of Scorn",
                    French = "Cercle du destin",
                    German = "Kreis der Verachtung",
                    Japanese = "サークル・オブ・ドゥーム"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(249, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Flaming Arrow",
                    English = "Flaming Arrow",
                    French = "Flèche enflammée",
                    German = "Flammenpfeil",
                    Japanese = "フレイミングアロー"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(250, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Burns",
                    English = "Burns",
                    French = "Brûlure",
                    German = "Brandwunde",
                    Japanese = "火傷"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(251, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Inner Quiet",
                    English = "Inner Quiet",
                    French = "Calme intérieur",
                    German = "Innere Ruhe",
                    Japanese = "インナークワイエット"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(252, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Waste Not",
                    English = "Waste Not",
                    French = "Parcimonie",
                    German = "Nachhaltigkeit",
                    Japanese = "倹約"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(253, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Steady Hand",
                    English = "Steady Hand",
                    French = "Main sûre",
                    German = "Ruhige Hand",
                    Japanese = "ステディハンド"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(254, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Great Strides",
                    English = "Great Strides",
                    French = "Grands progrès",
                    German = "Große Schritte",
                    Japanese = "グレートストライド"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(255, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Ingenuity",
                    English = "Ingenuity",
                    French = "Ingéniosité",
                    German = "Einfallsreichtum",
                    Japanese = "工面算段"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(256, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "加工 II",
                    English = "Ingenuity II",
                    French = "Ingéniosité II",
                    German = "Einfallsreichtum II",
                    Japanese = "工面算段II"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(257, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "俭约 II",
                    English = "Waste Not II",
                    French = "Parcimonie II",
                    German = "Nachhaltigkeit II",
                    Japanese = "倹約II"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(258, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Manipulation",
                    English = "Manipulation",
                    French = "Manipulation",
                    German = "Manipulation",
                    Japanese = "マニピュレーション"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(259, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "新颖",
                    English = "Innovation",
                    French = "Innovation",
                    German = "Innovation",
                    Japanese = "イノベーション"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(260, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Reclaim",
                    English = "Reclaim",
                    French = "Récupération",
                    German = "Reklamation",
                    Japanese = "リクレイム"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(261, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Comfort Zone",
                    English = "Comfort Zone",
                    French = "Zone de confort",
                    German = "Komfortzone",
                    Japanese = "コンファートゾーン"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(262, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Steady Hand II",
                    English = "Steady Hand II",
                    French = "Main sûre II",
                    German = "Ruhige Hand II",
                    Japanese = "ステディハンドII"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(263, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Damage Up",
                    English = "Damage Up",
                    French = "Bonus de dégâts",
                    German = "Schaden +",
                    Japanese = "ダメージ上昇"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(264, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Flesh Wound",
                    English = "Flesh Wound",
                    French = "Blessure physique",
                    German = "Fleischwunde",
                    Japanese = "切傷"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(265, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Stab Wound",
                    English = "Stab Wound",
                    French = "Perforation",
                    German = "Stichwunde",
                    Japanese = "刺傷"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(266, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Concussion",
                    English = "Concussion",
                    French = "Concussion",
                    German = "Prellung",
                    Japanese = "打撲傷"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(267, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Burns",
                    English = "Burns",
                    French = "Brûlure",
                    German = "Brandwunde",
                    Japanese = "火傷"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(268, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Frostbite",
                    English = "Frostbite",
                    French = "Gelure",
                    German = "Erfrierung",
                    Japanese = "凍傷"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(269, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Windburn",
                    English = "Windburn",
                    French = "Brûlure du vent",
                    German = "Beißender Wind",
                    Japanese = "裂傷"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(270, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Sludge",
                    English = "Sludge",
                    French = "Emboué",
                    German = "Schlamm",
                    Japanese = "汚泥"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(271, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Electrocution",
                    English = "Electrocution",
                    French = "Électrocution",
                    German = "Stromschlag",
                    Japanese = "感電"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(272, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Dropsy",
                    English = "Dropsy",
                    French = "Œdème",
                    German = "Wassersucht",
                    Japanese = "水毒"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(273, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Bleeding",
                    English = "Bleeding",
                    French = "Saignant",
                    German = "Blutung",
                    Japanese = "ペイン"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(274, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Recuperation",
                    English = "Recuperation",
                    French = "Rétablissement",
                    German = "Segnung",
                    Japanese = "治癒"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(275, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Poison +1",
                    English = "Poison +1",
                    French = "Poison",
                    German = "Gift +1",
                    Japanese = "毒"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(276, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Voice of Valor",
                    English = "Voice of Valor",
                    French = "Voix de la valeur",
                    German = "Lob des Kämpen",
                    Japanese = "勇戦の誉れ：効果"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(277, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Voice of Fortitude",
                    English = "Voice of Fortitude",
                    French = "Voix de la ténacité",
                    German = "Stimme der Stärke",
                    Japanese = "堅忍の誉れ：効果"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(278, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Relentless March",
                    English = "Relentless March",
                    French = "Marche implacable",
                    German = "無敵の進撃マーチ：効果",
                    Japanese = "無敵の進撃マーチ：効果"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(279, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Rehabilitation",
                    English = "Rehabilitation",
                    French = "Recouvrement",
                    German = "Rehabilitation",
                    Japanese = "徐々にＨＰ回復"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(280, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Bind",
                    English = "Bind",
                    French = "Entrave",
                    German = "Fessel",
                    Japanese = "バインド"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(281, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Physical Damage Down",
                    English = "Physical Damage Down",
                    French = "Malus de dégâts physiques",
                    German = "Schadenswert -",
                    Japanese = "物理ダメージ低下"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(282, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Mana Modulation",
                    English = "Mana Modulation",
                    French = "Anormalité magique",
                    German = "Magieschaden -",
                    Japanese = "魔力変調"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(283, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "水毒",
                    English = "Dropsy",
                    French = "Œdème",
                    German = "Wassersucht",
                    Japanese = "水毒"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(284, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "火伤",
                    English = "Burns",
                    French = "Brûlure",
                    German = "Brandwunde",
                    Japanese = "火傷"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(285, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "冻伤",
                    English = "Frostbite",
                    French = "Gelure",
                    German = "Erfrierung",
                    Japanese = "凍傷"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(286, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "裂伤",
                    English = "Windburn",
                    French = "Brûlure du vent",
                    German = "Beißender Wind",
                    Japanese = "裂傷"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(287, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "污泥",
                    English = "Sludge",
                    French = "Emboué",
                    German = "Schlamm",
                    Japanese = "汚泥"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(288, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "感电",
                    English = "Electrocution",
                    French = "Électrocution",
                    German = "Stromschlag",
                    Japanese = "感電"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(289, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Dropsy",
                    English = "Dropsy",
                    French = "Œdème",
                    German = "Wassersucht",
                    Japanese = "水毒"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(290, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Damage Up",
                    English = "Damage Up",
                    French = "Bonus de dégâts",
                    German = "Schaden +",
                    Japanese = "ダメージ上昇"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(291, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "百烈拳",
                    English = "Hundred Fists",
                    French = "Cent poings",
                    German = "100 Fäuste",
                    Japanese = "百烈拳"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(292, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Fetters",
                    English = "Fetters",
                    French = "Attache",
                    German = "Granitgefängnis",
                    Japanese = "拘束"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(293, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "技能速度提升",
                    English = "Skill Speed Up",
                    French = "Bonus de vivacité",
                    German = "Schnelligkeit +",
                    Japanese = "スキルスピード上昇"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(294, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Spell Speed Up",
                    English = "Spell Speed Up",
                    French = "Bonus de célérité",
                    German = "Zaubertempo +",
                    Japanese = "スペルスピード上昇"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(295, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Goldbile",
                    English = "Goldbile",
                    French = "Eau bilieuse",
                    German = "Goldlunge",
                    Japanese = "黄毒沼"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(296, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Hysteria",
                    English = "Hysteria",
                    French = "Hystérie",
                    German = "Panik",
                    Japanese = "恐慌"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(297, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Galvanize",
                    English = "Galvanize",
                    French = "Traité du réconfort",
                    German = "Adloquium",
                    Japanese = "鼓舞"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(298, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Sacred Soil",
                    English = "Sacred Soil",
                    French = "Dogme de survie",
                    German = "Geweihte Erde",
                    Japanese = "野戦治療の陣"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(299, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Sacred Soil",
                    English = "Sacred Soil",
                    French = "Dogme de survie",
                    German = "Geweihte Erde",
                    Japanese = "野戦治療の陣：効果"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(300, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Damage Up",
                    English = "Damage Up",
                    French = "Bonus de dégâts",
                    German = "Schaden +",
                    Japanese = "ダメージ上昇"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(301, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Critical Strikes",
                    English = "Critical Strikes",
                    French = "Coups critiques",
                    German = "Kritische Attacke",
                    Japanese = "クリティカル攻撃"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(302, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Gold Lung",
                    English = "Gold Lung",
                    French = "Poumons bilieux",
                    German = "Galle",
                    Japanese = "黄毒"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(303, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Burrs",
                    English = "Burrs",
                    French = "Bardanes",
                    German = "Klettenpilz",
                    Japanese = "粘菌"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(304, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Aetherflow",
                    English = "Aetherflow",
                    French = "Flux d'éther",
                    German = "Ätherfluss",
                    Japanese = "エーテルフロー"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(305, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "The Dragon's Curse",
                    English = "The Dragon's Curse",
                    French = "Malédiction du dragon",
                    German = "Bann des Drachen",
                    Japanese = "竜の呪縛"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(306, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Inner Dragon",
                    English = "Inner Dragon",
                    French = "Dragon intérieur",
                    German = "Kraft des Drachen",
                    Japanese = "竜の力"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(307, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Voice of Valor",
                    English = "Voice of Valor",
                    French = "Voix de la valeur",
                    German = "Lob des Kämpen",
                    Japanese = "勇戦の誉れ"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(308, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Voice of Fortitude",
                    English = "Voice of Fortitude",
                    French = "Voix de la ténacité",
                    German = "Stimme der Stärke",
                    Japanese = "堅忍の誉れ"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(309, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Relentless March",
                    English = "Relentless March",
                    French = "Marche implacable",
                    German = "Marsch ohne Rücksicht",
                    Japanese = "無敵の進撃マーチ（仮）"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(310, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "突风",
                    English = "Curl",
                    French = "Pelotonnement",
                    German = "Einrollen",
                    Japanese = "かたまり"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(311, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Earthen Ward",
                    English = "Earthen Ward",
                    French = "Barrière terrestre",
                    German = "Erdengewahrsam",
                    Japanese = "大地の守り"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(312, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Razed Earth",
                    English = "Razed Earth",
                    French = "Fureur tellurique",
                    German = "Gaias Zorn",
                    Japanese = "大地の怒り"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(313, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Radiant Shield",
                    English = "Radiant Shield",
                    French = "Bouclier radiant",
                    German = "Glühender Schild",
                    Japanese = "光輝の盾"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(314, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Inferno",
                    English = "Inferno",
                    French = "Flammes de l'enfer",
                    German = "Inferno",
                    Japanese = "地獄の火炎"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(315, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Whispering Dawn",
                    English = "Whispering Dawn",
                    French = "Murmure de l'aurore",
                    German = "Erhebendes Flüstern",
                    Japanese = "光の囁き"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(316, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Fey Covenant",
                    English = "Fey Covenant",
                    French = "Alliance féerique",
                    German = "Feenverheißung",
                    Japanese = "フェイコヴナント"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(317, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Fey Illumination",
                    English = "Fey Illumination",
                    French = "Illumination féerique",
                    German = "Illumination",
                    Japanese = "フェイイルミネーション"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(318, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Fey Glow",
                    English = "Fey Glow",
                    French = "Lueur féerique",
                    German = "Sprühender Glanz",
                    Japanese = "フェイグロウ"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(319, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Fey Light",
                    English = "Fey Light",
                    French = "Lumière féerique",
                    German = "Feenlicht",
                    Japanese = "フェイライト"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(320, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "流血",
                    English = "Bleeding",
                    French = "Saignant",
                    German = "Blutung",
                    Japanese = "ペイン"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(321, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Gungnir",
                    English = "Gungnir",
                    French = "Gungnir",
                    German = "Gugnir",
                    Japanese = "グングニルの槍"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(322, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "水晶纱帐",
                    English = "Crystal Veil",
                    French = "Voile cristallin",
                    German = "Kristallschleier",
                    Japanese = "クリスタルヴェール"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(323, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "免疫低下",
                    English = "Reduced Immunity",
                    French = "Immunité réduite",
                    German = "Schwache Immunabwehr",
                    Japanese = "免疫低下"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(324, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Greenwrath",
                    English = "Greenwrath",
                    French = "Ire de la forêt",
                    German = "Sintmal",
                    Japanese = "森の悲憤"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(325, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "无敌",
                    English = "Invincibility",
                    French = "Invulnérable",
                    German = "Unverwundbar",
                    Japanese = "無敵"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(326, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Lightning Charge",
                    English = "Lightning Charge",
                    French = "Charge électrique",
                    German = "Statische Ladung",
                    Japanese = "帯電"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(327, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Ice Charge",
                    English = "Ice Charge",
                    French = "Charge glacée",
                    German = "Eisige Ladung",
                    Japanese = "帯氷"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(328, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Heart of the Mountain",
                    English = "Heart of the Mountain",
                    French = "Cœur de la montagne",
                    German = "Herz des Felsgotts",
                    Japanese = "岩神の心石"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(329, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Modification",
                    English = "Modification",
                    French = "Récupération robotique",
                    German = "Fortifikationsprogramm 1",
                    Japanese = "自己強化プログラム"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(330, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Haste",
                    English = "Haste",
                    French = "Hâte",
                    German = "Hast",
                    Japanese = "ヘイスト"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(331, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "受到的魔法伤害下降",
                    English = "Magic Vulnerability Down",
                    French = "Vulnérabilité magique diminuée",
                    German = "Verringerte Magie-Verwundbarkeit",
                    Japanese = "被魔法ダメージ軽減"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(332, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Damage Up",
                    English = "Damage Up",
                    French = "Bonus de dégâts",
                    German = "Schaden +",
                    Japanese = "ダメージ上昇"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(333, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Allagan Rot",
                    English = "Allagan Rot",
                    French = "Pourriture allagoise",
                    German = "Allagische Fäulnis",
                    Japanese = "アラガンロット"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(334, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Allagan Immunity",
                    English = "Allagan Immunity",
                    French = "Anticorps allagois",
                    German = "Allagische Immunität",
                    Japanese = "アラガンロット抗体"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(335, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Firestream",
                    English = "Firestream",
                    French = "Courants de feu",
                    German = "Feuerstrahlen",
                    Japanese = "ファイアストリーム"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(336, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Sequence AB1",
                    English = "Sequence AB1",
                    French = "Séquence AB1",
                    German = "Sequenz AB1",
                    Japanese = "対打撃プログラム"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(337, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Sequence AP1",
                    English = "Sequence AP1",
                    French = "Séquence AP1",
                    German = "Sequenz AP1",
                    Japanese = "対突撃プログラム"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(338, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Sequence AS1",
                    English = "Sequence AS1",
                    French = "Séquence AS1",
                    German = "Sequenz AS1",
                    Japanese = "対斬撃プログラム"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(339, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "流血",
                    English = "Bleeding",
                    French = "Saignant",
                    German = "Blutung",
                    Japanese = "ペイン"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(340, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "物理壁垒",
                    English = "Physical Field",
                    French = "Champ physique",
                    German = "Physisches Feld",
                    Japanese = "対物理障壁"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(341, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Aetherial Field",
                    English = "Aetherial Field",
                    French = "Champ éthéré",
                    German = "Magisches Feld",
                    Japanese = "対魔法障壁"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(342, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Repelling Spray",
                    English = "Repelling Spray",
                    French = "Réplique",
                    German = "Reflektorschild",
                    Japanese = "応射"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(343, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Bleeding",
                    English = "Bleeding",
                    French = "Saignant",
                    German = "Blutung",
                    Japanese = "ペイン"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(344, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Neurolink",
                    English = "Neurolink",
                    French = "Neurolien",
                    German = "Neurolink",
                    Japanese = "拘束装置"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(345, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Recharge",
                    English = "Recharge",
                    French = "Recharge",
                    German = "Aufladung",
                    Japanese = "魔力供給"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(346, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Waxen Flesh",
                    English = "Waxen Flesh",
                    French = "Chair fondue",
                    German = "Wächserne Haut",
                    Japanese = "帯炎"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(347, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Pox",
                    English = "Pox",
                    French = "Vérole",
                    German = "Pocken",
                    Japanese = "ポックス"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(348, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Disseminate",
                    English = "Disseminate",
                    French = "Dissémination",
                    German = "Aussäen",
                    Japanese = "ディスセミネイト"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(349, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Steel Scales",
                    English = "Steel Scales",
                    French = "Écailles d'acier",
                    German = "Stahlschuppen",
                    Japanese = "スチールスケール"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(350, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Vulnerability Down",
                    English = "Vulnerability Down",
                    French = "Vulnérabilité diminuée",
                    German = "Verringerte Verwundbarkeit",
                    Japanese = "被ダメージ低下"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(351, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Rancor",
                    English = "Rancor",
                    French = "Rancune",
                    German = "Groll",
                    Japanese = "怨み"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(352, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Spjot",
                    English = "Spjot",
                    French = "Spjot",
                    German = "Gugnirs Zauber",
                    Japanese = "グングニルの魔力"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(353, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Brave New World",
                    English = "Brave New World",
                    French = "Un nouveau monde",
                    German = "Startbonus",
                    Japanese = "カンパニーアクション：ビギナーボーナス"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(354, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Live off the Land",
                    English = "Live off the Land",
                    French = "Vivre de la terre",
                    German = "Sammelgeschick-Bonus",
                    Japanese = "カンパニーアクション：獲得力アップ"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(355, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "What You See",
                    English = "What You See",
                    French = "Avoir le coup d'œil",
                    German = "Wahrnehmungsbonus",
                    Japanese = "カンパニーアクション：識質力アップ"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(356, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Eat from the Hand",
                    English = "Eat from the Hand",
                    French = "La main qui nourrit",
                    German = "Kunstfertigkeits-Bonus",
                    Japanese = "カンパニーアクション：作業精度アップ"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(357, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "In Control",
                    English = "In Control",
                    French = "Passer maître",
                    German = "Kontrolle-Bonus",
                    Japanese = "カンパニーアクション：加工精度アップ"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(358, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Snowman",
                    English = "Snowman",
                    French = "Bonhomme de neige",
                    German = "Schneemann",
                    Japanese = "雪だるま"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(359, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Fey Fire",
                    English = "Fey Fire",
                    French = "Feu follet",
                    German = "Feenfeuer",
                    Japanese = "妖炎"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(360, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Meat and Mead",
                    English = "Meat and Mead",
                    French = "À boire et à manger",
                    German = "Längere Nahrungseffekte",
                    Japanese = "カンパニーアクション：食事効果時間延長"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(361, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "That Which Binds Us",
                    English = "That Which Binds Us",
                    French = "Union parfaite",
                    German = "Bindungsbonus",
                    Japanese = "カンパニーアクション：錬精度上昇量アップ"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(362, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Proper Care",
                    English = "Proper Care",
                    French = "Protections protégées",
                    German = "Verminderter Verschleiß",
                    Japanese = "カンパニーアクション：装備品劣化低減"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(363, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Back on Your Feet",
                    English = "Back on Your Feet",
                    French = "Prompt rétablissement",
                    German = "Verkürzte Schwäche",
                    Japanese = "カンパニーアクション：衰弱時間短縮"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(364, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Reduced Rates",
                    English = "Reduced Rates",
                    French = "Prix d'ami",
                    German = "Vergünstigter Teleport",
                    Japanese = "カンパニーアクション：テレポ割引"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(365, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "The Heat of Battle",
                    English = "The Heat of Battle",
                    French = "Feu du combat",
                    German = "Kampfroutine-Bonus",
                    Japanese = "カンパニーアクション：討伐経験値アップ"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(366, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "A Man's Best Friend",
                    English = "A Man's Best Friend",
                    French = "Meilleur ami de l'homme",
                    German = "Mitstreiterroutine-Bonus",
                    Japanese = "カンパニーアクション：バディ経験値アップ"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(367, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Earth and Water",
                    English = "Earth and Water",
                    French = "Terre et eau",
                    German = "Sammelroutine-Bonus",
                    Japanese = "カンパニーアクション：採集経験値アップ"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(368, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Helping Hand",
                    English = "Helping Hand",
                    French = "Être en bonnes mains",
                    German = "Syntheseroutine-Bonus",
                    Japanese = "カンパニーアクション：製作経験値アップ"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(369, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Viscous Aetheroplasm",
                    English = "Viscous Aetheroplasm",
                    French = "Éthéroplasma",
                    German = "Ätheroplasma",
                    Japanese = "吸着爆雷"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(370, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Siren Song",
                    English = "Siren Song",
                    French = "Chant de la sirène",
                    German = "Sirenengesang",
                    Japanese = "セイレーンの歌声"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(371, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Zombification",
                    English = "Zombification",
                    French = "Zombi",
                    German = "Zombie",
                    Japanese = "ゾンビー"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(372, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Brood Rage",
                    English = "Brood Rage",
                    French = "Colère maternelle",
                    German = "Brutrage",
                    Japanese = "母鳥の怒り"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(373, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Blight",
                    English = "Blight",
                    French = "Insoignabilité",
                    German = "Unheilbar",
                    Japanese = "被回復無効"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(374, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Corrupted Crystal",
                    English = "Corrupted Crystal",
                    French = "Cristaux corrompus",
                    German = "Denaturierter Kristall",
                    Japanese = "偏属性クリスタル"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(375, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Suppuration",
                    English = "Suppuration",
                    French = "Morsure du feu",
                    German = "Verbrennung",
                    Japanese = "熱傷"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(376, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Searing Wind",
                    English = "Searing Wind",
                    French = "Fournaise",
                    German = "Gluthitze",
                    Japanese = "灼熱"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(377, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "炎狱之锁",
                    English = "Infernal Fetters",
                    French = "Chaînes infernales",
                    German = "Infernofesseln",
                    Japanese = "炎獄の鎖"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(378, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Death Throes",
                    English = "Death Throes",
                    French = "Affres de la mort",
                    German = "Agonales Klammern",
                    Japanese = "道連れ"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(379, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Thermal Low",
                    English = "Thermal Low",
                    French = "Basse pression",
                    German = "Tiefdruck",
                    Japanese = "低気圧"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(380, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Thermal High",
                    English = "Thermal High",
                    French = "Haute pression",
                    German = "Hochdruck",
                    Japanese = "高気圧"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(381, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Testudo",
                    English = "Testudo",
                    French = "Testudo",
                    German = "Testudo",
                    Japanese = "テストゥド"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(384, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Thrill of War",
                    English = "Thrill of War",
                    French = "Frisson de la guerre",
                    German = "Schlachtrausch",
                    Japanese = "スリル・オブ・ウォー"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(385, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Full Swing",
                    English = "Full Swing",
                    French = "Plein élan",
                    German = "Voller Schwinger",
                    Japanese = "フルスイング"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(386, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Somersault",
                    English = "Somersault",
                    French = "Saut périlleux",
                    German = "Salto",
                    Japanese = "サマーソルト"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(387, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Fetter Ward",
                    English = "Fetter Ward",
                    French = "Émancipation",
                    German = "Obhut",
                    Japanese = "フェターウォード"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(388, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Impulse Rush",
                    English = "Impulse Rush",
                    French = "Impulsion subite",
                    German = "Impuls-Ansturm",
                    Japanese = "インパルスラッシュ"
                },
                CompanyAction = true,
            });
            StatusEffects.Add(389, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Skewer",
                    English = "Skewer",
                    French = "Embrochement",
                    German = "Spieß",
                    Japanese = "スキュアー"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(390, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Sacred Prism",
                    English = "Sacred Prism",
                    French = "Prisme sacré",
                    German = "Barmherzigkeit",
                    Japanese = "女神の慈悲"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(391, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Phantom Dart",
                    English = "Phantom Dart",
                    French = "Projectile fantôme",
                    German = "Phantompfeil",
                    Japanese = "ファントムダート"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(392, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Misty Veil",
                    English = "Misty Veil",
                    French = "Voile de brume",
                    German = "Nebelschleier",
                    Japanese = "ミスティヴェール"
                },
                CompanyAction = true,
            });
            StatusEffects.Add(393, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Wither",
                    English = "Wither",
                    French = "Flétrissure",
                    German = "Entkräften",
                    Japanese = "ウィザー"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(394, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Focalization",
                    English = "Focalization",
                    French = "Traité de la focalisation",
                    German = "Lege Artis",
                    Japanese = "精神統一の策"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(395, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Aetheric Burst",
                    English = "Aetheric Burst",
                    French = "Explosion éthérée",
                    German = "Ätherschub",
                    Japanese = "エーテルバースト"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(396, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Equanimity",
                    English = "Equanimity",
                    French = "Équanimité",
                    German = "Gleichmut",
                    Japanese = "専心"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(397, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Attunement",
                    English = "Attunement",
                    French = "Harmonie",
                    German = "Einstimmung",
                    Japanese = "調和"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(398, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Astral Realignment",
                    English = "Astral Realignment",
                    French = "Alignement astral",
                    German = "Astralkörper",
                    Japanese = "アストラル体"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(399, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Corporeal Return",
                    English = "Corporeal Return",
                    French = "Retour corporel",
                    German = "Wiederkunft",
                    Japanese = "生還"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(400, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Charge",
                    English = "Charge",
                    French = "Charge électrique",
                    German = "Laden",
                    Japanese = "蓄電"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(401, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Seized",
                    English = "Seized",
                    French = "Étreinte mortelle",
                    German = "Umklammert",
                    Japanese = "捕獲"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(402, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Thrown for a Loop",
                    English = "Thrown for a Loop",
                    French = "Acharnement aveugle",
                    German = "Blinde Wut",
                    Japanese = "有頂天"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(403, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Damage Up",
                    English = "Damage Up",
                    French = "Bonus de dégâts",
                    German = "Schaden +",
                    Japanese = "ダメージ上昇"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(404, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Transporting",
                    English = "Transporting",
                    French = "Chargé",
                    German = "Transport",
                    Japanese = "運搬"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(405, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Bewildered",
                    English = "Bewildered",
                    French = "Égarement",
                    German = "Bezaubert",
                    Japanese = "幻惑"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(406, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Vulnerability Down",
                    English = "Vulnerability Down",
                    French = "Vulnérabilité diminuée",
                    German = "Verringerte Verwundbarkeit",
                    Japanese = "被ダメージ低下"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(407, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Dust Poisoning",
                    English = "Dust Poisoning",
                    French = "Empoisonnement cristallin",
                    German = "Staubvergiftung",
                    Japanese = "粉塵中毒"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(408, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Storm's Path",
                    English = "Storm's Path",
                    French = "Couperet de justice",
                    German = "Sturmkeil",
                    Japanese = "シュトルムヴィント"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(409, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Holmgang",
                    English = "Holmgang",
                    French = "Holmgang",
                    German = "Holmgang",
                    Japanese = "ホルムギャング"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(410, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Antibody",
                    English = "Antibody",
                    French = "Réaction antivirale",
                    German = "Antikörper",
                    Japanese = "ウイルス抗体"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(411, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Inner Beast",
                    English = "Inner Beast",
                    French = "Bête intérieure",
                    German = "Tier in dir",
                    Japanese = "原初の魂"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(412, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Hover",
                    English = "Hover",
                    French = "Élévation",
                    German = "Schweben",
                    Japanese = "滞空"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(413, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Mark Up",
                    English = "Mark Up",
                    French = "Marque des vainqueurs",
                    German = "Wolfsmarken-Bonus",
                    Japanese = "カンパニーアクション：対人戦績アップ"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(414, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Seal Sweetener",
                    English = "Seal Sweetener",
                    French = "Solde accrue",
                    German = "Staatstaler-Bonus",
                    Japanese = "カンパニーアクション：軍票アップ"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(415, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Regain",
                    English = "Regain",
                    French = "Regain",
                    German = "Erholen",
                    Japanese = "ＴＰ継続回復"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(416, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Transparent",
                    English = "Transparent",
                    French = "Transparence",
                    German = "Transparenz",
                    Japanese = "透明"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(417, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Protect",
                    English = "Protect",
                    French = "Bouclier",
                    German = "Protes",
                    Japanese = "プロテス"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(418, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Physical Vulnerability Down",
                    English = "Physical Vulnerability Down",
                    French = "Vulnérabilité physique diminuée",
                    German = "Verringerte physische Verwundbarkeit",
                    Japanese = "被物理ダメージ軽減"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(419, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Misty Veil",
                    English = "Misty Veil",
                    French = "Voile de brume",
                    German = "Nebelschleier",
                    Japanese = "ミスティヴェール"
                },
                CompanyAction = true,
            });
            StatusEffects.Add(420, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Prey",
                    English = "Prey",
                    French = "Marquage",
                    German = "Markiert",
                    Japanese = "マーキング"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(421, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Devoured",
                    English = "Devoured",
                    French = "Dévorement",
                    German = "Halbverschlungen",
                    Japanese = "捕食"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(422, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Healing Magic Down",
                    English = "Healing Magic Down",
                    French = "Malus de soin",
                    German = "Heilmagie -",
                    Japanese = "回復魔法効果低下"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(423, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Nightmare",
                    English = "Nightmare",
                    French = "Cauchemar",
                    German = "Albtraum",
                    Japanese = "悪夢"
                },
                CompanyAction = true,
            });
            StatusEffects.Add(424, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Diabolic Curse",
                    English = "Diabolic Curse",
                    French = "Maléfice du néant",
                    German = "Diabolischer Fluch",
                    Japanese = "ヴォイドの呪詛"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(425, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Eerie Air",
                    English = "Eerie Air",
                    French = "Présence du néant",
                    German = "Diabolische Aura",
                    Japanese = "ヴォイドの妖気"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(426, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Noctoshield",
                    English = "Noctoshield",
                    French = "Nocto-bouclier",
                    German = "Nachtschild",
                    Japanese = "ノクトシールド"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(427, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Slow+",
                    English = "Slow+",
                    French = "Lenteur +",
                    German = "Gemach +",
                    Japanese = "スロウ＋"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(428, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Haste+",
                    English = "Haste+",
                    French = "Hâte +",
                    German = "Hast +",
                    Japanese = "ヘイスト＋"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(429, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Scale Flakes",
                    English = "Scale Flakes",
                    French = "Poussière érosive",
                    German = "Erosionsstaub",
                    Japanese = "妖鱗粉"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(430, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Misery",
                    English = "Misery",
                    French = "Désolation",
                    German = "Kummer",
                    Japanese = "悲嘆"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(431, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Water Resistance Down",
                    English = "Water Resistance Down",
                    French = "Vulnérabilité à l'eau",
                    German = "Wasserresistenz -",
                    Japanese = "水属性耐性低下"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(432, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Briny Mirror",
                    English = "Briny Mirror",
                    French = "Reflets d'eau libérés",
                    German = "Wassermembran",
                    Japanese = "水鏡飛散"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(433, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Briny Veil",
                    English = "Briny Veil",
                    French = "Reflet d'eau",
                    German = "Wasserspiegelung",
                    Japanese = "水鏡"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(434, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Absolute Bind",
                    English = "Absolute Bind",
                    French = "Étreinte impénétrable",
                    German = "Absoluter Bann",
                    Japanese = "完全呪縛"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(435, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Demon Eye",
                    English = "Demon Eye",
                    French = "Œil diabolique",
                    German = "Dämonenauge",
                    Japanese = "悪魔の瞳"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(436, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Briar",
                    English = "Briar",
                    French = "Ronces sauvages",
                    German = "Dorngestrüpp",
                    Japanese = "野茨"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(437, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Stone Curse",
                    English = "Stone Curse",
                    French = "Piège de pierre",
                    German = "Steinfluch",
                    Japanese = "石化の呪い"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(438, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Minimum",
                    English = "Minimum",
                    French = "Mini",
                    German = "Wicht",
                    Japanese = "ミニマム"
                },
                CompanyAction = true,
            });
            StatusEffects.Add(439, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Toad",
                    English = "Toad",
                    French = "Crapaud",
                    German = "Frosch",
                    Japanese = "トード"
                },
                CompanyAction = true,
            });
            StatusEffects.Add(440, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Minimum",
                    English = "Minimum",
                    French = "Mini",
                    German = "Wicht",
                    Japanese = "ミニマム"
                },
                CompanyAction = true,
            });
            StatusEffects.Add(441, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Toad",
                    English = "Toad",
                    French = "Crapaud",
                    German = "Frosch",
                    Japanese = "トード"
                },
                CompanyAction = true,
            });
            StatusEffects.Add(442, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Slow",
                    English = "Slow",
                    French = "Lenteur",
                    German = "Gemach",
                    Japanese = "スロウ"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(443, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Damage Up",
                    English = "Damage Up",
                    French = "Bonus de dégâts",
                    German = "Schaden +",
                    Japanese = "ダメージ上昇"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(444, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Vulnerability Up",
                    English = "Vulnerability Up",
                    French = "Vulnérabilité augmentée",
                    German = "Erhöhte Verwundbarkeit",
                    Japanese = "被ダメージ上昇"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(445, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Thorny Vine",
                    English = "Thorny Vine",
                    French = "Sarment de ronces",
                    German = "Dornenranken",
                    Japanese = "茨の蔓"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(446, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Honey-glazed",
                    English = "Honey-glazed",
                    French = "Mielleux",
                    German = "Honigsüß",
                    Japanese = "蜂蜜"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(447, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Potent Acid",
                    English = "Potent Acid",
                    French = "Acide corrosif",
                    German = "Konzentrierte Säure",
                    Japanese = "強酸"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(448, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Swarmed",
                    English = "Swarmed",
                    French = "Essaim",
                    German = "Umschwärmt",
                    Japanese = "スウォーム"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(449, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Stung",
                    English = "Stung",
                    French = "Dard",
                    German = "Gestochen",
                    Japanese = "蜂刺症"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(450, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Petrification Resistance",
                    English = "Petrification Resistance",
                    French = "Résistance à Pétrification",
                    German = "Steinresistenz",
                    Japanese = "石化無効"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(451, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Cursed Voice",
                    English = "Cursed Voice",
                    French = "Voix du maléfice",
                    German = "Stimme der Verwünschung",
                    Japanese = "呪詛の声"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(452, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Cursed Shriek",
                    English = "Cursed Shriek",
                    French = "Cri du maléfice",
                    German = "Schrei der Verwünschung",
                    Japanese = "呪詛の叫声"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(453, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Allagan Venom",
                    English = "Allagan Venom",
                    French = "Venin allagois",
                    German = "Allagisches Gift",
                    Japanese = "アラガンポイズン"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(454, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Allagan Field",
                    English = "Allagan Field",
                    French = "Champ allagois",
                    German = "Allagisches Feld",
                    Japanese = "アラガンフィールド"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(455, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Languishing",
                    English = "Languishing",
                    French = "Agonie vitale",
                    German = "Ermattung",
                    Japanese = "生気減退"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(456, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Maximum HP Down",
                    English = "Maximum HP Down",
                    French = "PV maximum réduits",
                    German = "LP-Malus",
                    Japanese = "最大ＨＰダウン"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(457, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Bind+",
                    English = "Bind+",
                    French = "Entrave +",
                    German = "Fessel +",
                    Japanese = "バインド＋"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(458, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Raven Blight",
                    English = "Raven Blight",
                    French = "Bile de rapace",
                    German = "Pestschwinge",
                    Japanese = "凶鳥毒気"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(459, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Normal Stance",
                    English = "Normal Stance",
                    French = "Posture normale",
                    German = "Normales Verhalten",
                    Japanese = "ノーマルスタンス"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(460, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Aggressive Stance",
                    English = "Aggressive Stance",
                    French = "Posture d'attaque",
                    German = "Aggressives Verhalten",
                    Japanese = "アタッカースタンス"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(461, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Subversive Stance",
                    English = "Subversive Stance",
                    French = "Posture de diversion",
                    German = "Hemmendes Verhalten",
                    Japanese = "ジャマースタンス"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(462, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Garrote Twist",
                    English = "Garrote Twist",
                    French = "Sangle accélérée",
                    German = "Leicht fixierbar",
                    Japanese = "拘束加速"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(463, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Garrote",
                    English = "Garrote",
                    French = "Attache",
                    German = "Fixierungsfessel",
                    Japanese = "拘束"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(464, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Firescorched",
                    English = "Firescorched",
                    French = "Corne-de-feu",
                    German = "Feuerhorn",
                    Japanese = "ファイアホーン"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(465, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Icebitten",
                    English = "Icebitten",
                    French = "Griffe-de-glace",
                    German = "Eisklaue",
                    Japanese = "アイスクロウ"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(466, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Thunderstruck",
                    English = "Thunderstruck",
                    French = "Aile-de-foudre",
                    German = "Donnerschwinge",
                    Japanese = "サンダーウィング"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(467, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Briny Veil",
                    English = "Briny Veil",
                    French = "Reflet d'eau",
                    German = "Wasserspiegelung",
                    Japanese = "水鏡"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(468, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Voidbound",
                    English = "Voidbound",
                    French = "Transfert du néant",
                    German = "Nichtsgebunden",
                    Japanese = "異界の狭間"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(469, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "High and Mighty",
                    English = "High and Mighty",
                    French = "Monarchie absolue",
                    German = "Absoluter Herrscher",
                    Japanese = "極王"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(470, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Pombination",
                    English = "Pombination",
                    French = "Mogtimisation",
                    German = "Pombination",
                    Japanese = "モグビネーション"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(471, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Moglight Resistance Down",
                    English = "Moglight Resistance Down",
                    French = "Nyctophobie mog",
                    German = "Mogryschatten-Aversion",
                    Japanese = "モグ闇過敏症"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(472, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Mogdark Resistance Down",
                    English = "Mogdark Resistance Down",
                    French = "Photophobie mog",
                    German = "Moglicht-Empfindlichkeit",
                    Japanese = "モグ光過敏症"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(473, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Bemoggled",
                    English = "Bemoggled",
                    French = "Tournis mog",
                    German = "Tohuwabohu-Wahn",
                    Japanese = "モグルグル"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(474, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Royal Rouse",
                    English = "Royal Rouse",
                    French = "Mogtivation",
                    German = "Mogul-Fanfare",
                    Japanese = "闘魂"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(475, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Slippery Prey",
                    English = "Slippery Prey",
                    French = "Marquage impossible",
                    German = "Unmarkierbar",
                    Japanese = "マーキング対象外"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(476, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Gloam",
                    English = "Gloam",
                    French = "Voile ombreux",
                    German = "Dämmerlicht",
                    Japanese = "薄闇"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(477, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Mantle of the Whorl",
                    English = "Mantle of the Whorl",
                    French = "Manteau du Déchaîneur",
                    German = "Wogenmantel",
                    Japanese = "水神のマント"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(478, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Veil of the Whorl",
                    English = "Veil of the Whorl",
                    French = "Voile du Déchaîneur",
                    German = "Wogenschleier",
                    Japanese = "水神のヴェール"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(479, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Rehabilitation",
                    English = "Rehabilitation",
                    French = "Recouvrement",
                    German = "Rehabilitation",
                    Japanese = "徐々にＨＰ回復"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(480, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Haste+",
                    English = "Haste+",
                    French = "Hâte +",
                    German = "Hast +",
                    Japanese = "ヘイスト＋"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(481, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Sprint",
                    English = "Sprint",
                    French = "Sprint",
                    German = "Sprint",
                    Japanese = "スプリント"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(482, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Paralysis",
                    English = "Paralysis",
                    French = "Paralysie",
                    German = "Paralyse",
                    Japanese = "麻痺"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(483, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "HP Boost",
                    English = "HP Boost",
                    French = "Bonus de PV",
                    German = "LP-Bonus",
                    Japanese = "最大ＨＰアップ"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(484, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Ink",
                    English = "Ink",
                    French = "Sépia venimeux",
                    German = "Toxische Tinte",
                    Japanese = "毒墨"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(485, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Dropsy",
                    English = "Dropsy",
                    French = "Œdème",
                    German = "Wassersucht",
                    Japanese = "水毒"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(486, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Watery Grave",
                    English = "Watery Grave",
                    French = "Geôle aqueuse",
                    German = "Wasserkäfig",
                    Japanese = "水牢"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(487, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Deep Freeze",
                    English = "Deep Freeze",
                    French = "Congélation",
                    German = "Tiefkühlung",
                    Japanese = "氷結"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(488, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Perfect Dodge",
                    English = "Perfect Dodge",
                    French = "Esquive absolue",
                    German = "Superkniff",
                    Japanese = "残影"
                },
                CompanyAction = true,
            });
            StatusEffects.Add(489, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Kiss of the Wasp",
                    English = "Kiss of the Wasp",
                    French = "Baiser de guêpe",
                    German = "Wespenkuss",
                    Japanese = "蜂毒"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(490, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Kiss of the Viper",
                    English = "Kiss of the Viper",
                    French = "Baiser de vipère",
                    German = "Vipernkuss",
                    Japanese = "蛇毒"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(491, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Dancing Edge",
                    English = "Dancing Edge",
                    French = "Lame dansante",
                    German = "Tanzende Schneide",
                    Japanese = "舞踏刃"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(492, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Mutilation",
                    English = "Mutilation",
                    French = "Attaque mutilante",
                    German = "Verstümmeln",
                    Japanese = "無双旋"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(494, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Shadow Fang",
                    English = "Shadow Fang",
                    French = "Croc d'ombre",
                    German = "Schattenfang",
                    Japanese = "一閃"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(495, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Goad",
                    English = "Goad",
                    French = "Aiguillonnement",
                    German = "Dampf",
                    Japanese = "叱咤"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(496, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Mudra",
                    English = "Mudra",
                    French = "Mudrâ",
                    German = "Mudra",
                    Japanese = "印"
                },
                CompanyAction = true,
            });
            StatusEffects.Add(497, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Kassatsu",
                    English = "Kassatsu",
                    French = "Kassatsu",
                    German = "Kassatsu",
                    Japanese = "活殺自在"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(500, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Huton",
                    English = "Huton",
                    French = "Fûton",
                    German = "Huton",
                    Japanese = "風遁の術"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(501, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Doton",
                    English = "Doton",
                    French = "Doton",
                    German = "Doton",
                    Japanese = "土遁の術"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(502, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Doton Heavy",
                    English = "Doton Heavy",
                    French = "Pesanteur",
                    German = "Gewicht",
                    Japanese = "ヘヴィ"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(504, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Fetters",
                    English = "Fetters",
                    French = "Attache",
                    German = "Gefesselt",
                    Japanese = "拘束"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(505, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Damage Up",
                    English = "Damage Up",
                    French = "Bonus de dégâts",
                    German = "Schaden +",
                    Japanese = "ダメージ上昇"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(506, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Vertigo",
                    English = "Vertigo",
                    French = "Vertige",
                    German = "Schwindel",
                    Japanese = "目眩"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(507, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Suiton",
                    English = "Suiton",
                    French = "Suiton",
                    German = "Suiton",
                    Japanese = "水遁の術"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(508, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Shadow Fang",
                    English = "Shadow Fang",
                    French = "Croc d'ombre",
                    German = "Schattenfang",
                    Japanese = "影牙"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(509, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Aetherochemical Bomb",
                    English = "Aetherochemical Bomb",
                    French = "Magismobombe",
                    German = "Magitek-Sprengkörper",
                    Japanese = "魔爆弾"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(510, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Fetters",
                    English = "Fetters",
                    French = "Attache",
                    German = "Gefesselt",
                    Japanese = "拘束"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(511, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Fire Toad",
                    English = "Fire Toad",
                    French = "Pyrocrapaud",
                    German = "Knallfrosch",
                    Japanese = "ファイアトード"
                },
                CompanyAction = true,
            });
            StatusEffects.Add(512, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Electroconductivity",
                    English = "Electroconductivity",
                    French = "Électroconductivité",
                    German = "Elektrokonduktivität",
                    Japanese = "導電"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(513, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Static Condensation",
                    English = "Static Condensation",
                    French = "Charge électrostatique",
                    German = "Statische Ladung",
                    Japanese = "蓄電"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(514, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Causality",
                    English = "Causality",
                    French = "Causalité",
                    German = "Kausalität",
                    Japanese = "因果"
                },
                CompanyAction = true,
            });
            StatusEffects.Add(515, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Thunderclap",
                    English = "Thunderclap",
                    French = "Roulement de tonnerre",
                    German = "Rollender Donner",
                    Japanese = "雷鼓"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(516, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Chaos",
                    English = "Chaos",
                    French = "Chaos",
                    German = "Chaos",
                    Japanese = "混沌"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(517, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Surge Protection",
                    English = "Surge Protection",
                    French = "Parafoudre",
                    German = "Überspannungsschutz",
                    Japanese = "避雷"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(518, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Reflect",
                    English = "Reflect",
                    French = "Miroir",
                    German = "Reflektion",
                    Japanese = "リフレク"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(519, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Counter",
                    English = "Counter",
                    French = "Riposte",
                    German = "Konter",
                    Japanese = "カウンター"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(520, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Fire Resistance Up",
                    English = "Fire Resistance Up",
                    French = "Résistance au feu accrue",
                    German = "Feuerresistenz +",
                    Japanese = "火属性耐性向上"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(521, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Water Resistance Up",
                    English = "Water Resistance Up",
                    French = "Résistance à l'eau accrue",
                    German = "Wasserresistenz +",
                    Japanese = "水属性耐性向上"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(522, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Wind Resistance Up",
                    English = "Wind Resistance Up",
                    French = "Résistance au vent accrue",
                    German = "Windresistenz +",
                    Japanese = "風属性耐性向上"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(523, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Lightning Resistance Up",
                    English = "Lightning Resistance Up",
                    French = "Résistance à la foudre accrue",
                    German = "Blitzresistenz +",
                    Japanese = "雷属性耐性向上"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(524, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Earth Resistance Up",
                    English = "Earth Resistance Up",
                    French = "Résistance à la terre accrue",
                    German = "Erdresistenz +",
                    Japanese = "土属性耐性向上"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(525, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Ice Resistance Up",
                    English = "Ice Resistance Up",
                    French = "Résistance à la glace accrue",
                    German = "Eisresistenz +",
                    Japanese = "氷属性耐性向上"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(526, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Frost Blade",
                    English = "Frost Blade",
                    French = "Lame glaciale",
                    German = "Frostklinge",
                    Japanese = "凍てつく剣"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(527, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Frost Brand",
                    English = "Frost Brand",
                    French = "Bâton glacial",
                    German = "Froststab",
                    Japanese = "凍てつく杖"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(528, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Frost Bow",
                    English = "Frost Bow",
                    French = "Arc glacial",
                    German = "Frostbogen",
                    Japanese = "凍てつく弓"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(529, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Invincibility",
                    English = "Invincibility",
                    French = "Invulnérable",
                    German = "Unverwundbar",
                    Japanese = "無敵"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(530, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Burns",
                    English = "Burns",
                    French = "Brûlure",
                    German = "Brandwunde",
                    Japanese = "火傷"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(531, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Dropsy",
                    English = "Dropsy",
                    French = "Œdème",
                    German = "Wassersucht",
                    Japanese = "水毒"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(532, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Windburn",
                    English = "Windburn",
                    French = "Brûlure du vent",
                    German = "Beißender Wind",
                    Japanese = "裂傷"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(533, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Electrocution",
                    English = "Electrocution",
                    French = "Électrocution",
                    German = "Stromschlag",
                    Japanese = "感電"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(534, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Sludge",
                    English = "Sludge",
                    French = "Emboué",
                    German = "Schlamm",
                    Japanese = "汚泥"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(535, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Frostbite",
                    English = "Frostbite",
                    French = "Gelure",
                    German = "Erfrierung",
                    Japanese = "凍傷"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(536, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Companion EXP Up",
                    English = "Companion EXP Up",
                    French = "Compagnon d'expérience",
                    German = "Sternstunde der Mitstreiter",
                    Japanese = "バディ強化：経験値アップ"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(537, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Companion EXP Up II",
                    English = "Companion EXP Up II",
                    French = "Compagnon d'expérience II",
                    German = "Sternstunde der Mitstreiter II",
                    Japanese = "バディ強化：経験値アップII"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(538, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Companion Attack Up",
                    English = "Companion Attack Up",
                    French = "Compagnon d'attaque",
                    German = "Mitstreiter-Attackebonus",
                    Japanese = "バディ強化：攻撃力アップ"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(539, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Companion Attack Up II",
                    English = "Companion Attack Up II",
                    French = "Compagnon d'attaque II",
                    German = "Mitstreiter-Attackebonus II",
                    Japanese = "バディ強化：攻撃力アップII"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(540, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Companion Healing Potency Up",
                    English = "Companion Healing Potency Up",
                    French = "Compagnon attentionné",
                    German = "Mitstreiter-Heilmagiebonus",
                    Japanese = "バディ強化：魔法回復力アップ"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(541, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Companion Healing Potency Up II",
                    English = "Companion Healing Potency Up II",
                    French = "Compagnon attentioné II",
                    German = "Mitstreiter-Heilmagiebonus II",
                    Japanese = "バディ強化：魔法回復力アップII"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(542, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Companion Maximum HP Up",
                    English = "Companion Maximum HP Up",
                    French = "Compagnon gaillard",
                    German = "Mitstreiter-LP-Bonus",
                    Japanese = "バディ強化：最大ＨＰアップ"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(543, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Companion Maximum HP Up II",
                    English = "Companion Maximum HP Up II",
                    French = "Compagnon gaillard II",
                    German = "Mitstreiter-LP-Bonus II",
                    Japanese = "バディ強化：最大ＨＰアップII"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(544, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Companion Enmity Up",
                    English = "Companion Enmity Up",
                    French = "Compagnon boutefeu",
                    German = "Provokativer Mitstreiter",
                    Japanese = "バディ強化：敵視アップ"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(545, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Companion Enmity Up II",
                    English = "Companion Enmity Up II",
                    French = "Compagnon boutefeu II",
                    German = "Provokativer Mitstreiter II",
                    Japanese = "バディ強化：敵視アップII"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(546, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Enervation",
                    English = "Enervation",
                    French = "Dans les choux",
                    German = "Schöner Salat",
                    Japanese = "攻防低下"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(547, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Facility Access: Production",
                    English = "Facility Access: Production",
                    French = "Installation: production",
                    German = "Arbeitsstätte: Herstellung",
                    Japanese = "製作施設：部材工作"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(548, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Facility Access: Finishing",
                    English = "Facility Access: Finishing",
                    French = "Installation: finition",
                    German = "Arbeitsstätte: Veredelung",
                    Japanese = "製作施設：精密工作"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(549, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Facility Access: Detailing",
                    English = "Facility Access: Detailing",
                    French = "Installation: minutie",
                    German = "Arbeitsstätte: Feinarbeit",
                    Japanese = "製作施設：難関工作"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(550, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Facility Access: Production II",
                    English = "Facility Access: Production II",
                    French = "Installation: production II",
                    German = "Arbeitsstätte: Herstellung II",
                    Japanese = "製作施設：部材工作II"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(551, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Facility Access: Specialization",
                    English = "Facility Access: Specialization",
                    French = "Installation: spécialité",
                    German = "Arbeitsstätte: Spezialisierung",
                    Japanese = "製作施設：専門工作"
                },
                CompanyAction = true,
            });
            StatusEffects.Add(552, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Facility Access: Specialization II",
                    English = "Facility Access: Specialization II",
                    French = "Installation: spécialité II",
                    German = "Arbeitsstätte: Spezialisierung II",
                    Japanese = "製作施設：専門工作II"
                },
                CompanyAction = true,
            });
            StatusEffects.Add(553, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Facility Access: Detailing II",
                    English = "Facility Access: Detailing II",
                    French = "Installation: minutie II",
                    German = "Arbeitsstätte: Feinarbeit II",
                    Japanese = "製作施設：難関工作II"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(554, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Facility Access: Finishing II",
                    English = "Facility Access: Finishing II",
                    French = "Installation: finition II",
                    German = "Arbeitsstätte: Veredelung II",
                    Japanese = "製作施設：精密工作II"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(555, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Repelling Spray",
                    English = "Repelling Spray",
                    French = "Réplique",
                    German = "Reflektorschild",
                    Japanese = "応射"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(556, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Repelling Spray",
                    English = "Repelling Spray",
                    French = "Réplique",
                    German = "Reflektorschild",
                    Japanese = "応射"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(557, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Repelling Spray",
                    English = "Repelling Spray",
                    French = "Réplique",
                    German = "Reflektorschild",
                    Japanese = "応射"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(558, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Repelling Spray",
                    English = "Repelling Spray",
                    French = "Réplique",
                    German = "Reflektorschild",
                    Japanese = "応射"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(559, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Poison",
                    English = "Poison",
                    French = "Poison",
                    German = "Gift",
                    Japanese = "毒"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(560, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Poison",
                    English = "Poison",
                    French = "Poison",
                    German = "Gift",
                    Japanese = "毒"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(561, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Slow",
                    English = "Slow",
                    French = "Lenteur",
                    German = "Gemach",
                    Japanese = "スロウ"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(562, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Prey",
                    English = "Prey",
                    French = "Marquage",
                    German = "Markiert",
                    Japanese = "マーキング"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(563, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Vulnerability Up",
                    English = "Vulnerability Up",
                    French = "Vulnérabilité augmentée",
                    German = "Erhöhte Verwundbarkeit",
                    Japanese = "被ダメージ上昇"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(564, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Bind",
                    English = "Bind",
                    French = "Entrave",
                    German = "Fessel",
                    Japanese = "バインド"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(565, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Transfiguration",
                    English = "Transfiguration",
                    French = "Transformation",
                    German = "Verwandlung",
                    Japanese = "変身"
                },
                CompanyAction = true,
            });
            StatusEffects.Add(566, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Damage Up",
                    English = "Damage Up",
                    French = "Bonus de dégâts",
                    German = "Schaden +",
                    Japanese = "ダメージ上昇"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(567, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Shifting Sands",
                    English = "Shifting Sands",
                    French = "Sable mouvant",
                    German = "Treibsand",
                    Japanese = "流砂"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(568, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Fisher's Intuition",
                    English = "Fisher's Intuition",
                    French = "Instinct du pêcheur",
                    German = "Petri Heil",
                    Japanese = "漁師の直感"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(569, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Slime",
                    English = "Slime",
                    French = "Mucus",
                    German = "Schleim",
                    Japanese = "粘液"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(570, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "In the Line of Fire",
                    English = "In the Line of Fire",
                    French = "Dans la ligne de tir",
                    German = "In der Schusslinie",
                    Japanese = "エイム"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(571, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Blind",
                    English = "Blind",
                    French = "Cécité",
                    German = "Blind",
                    Japanese = "暗闇"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(572, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Slashing Resistance Down",
                    English = "Slashing Resistance Down",
                    French = "Résistance au tranchant réduite",
                    German = "Hiebresistenz -",
                    Japanese = "斬属性耐性低下"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(573, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Blunt Resistance Down",
                    English = "Blunt Resistance Down",
                    French = "Résistance au contondant réduite",
                    German = "Schlagresistenz -",
                    Japanese = "打属性耐性低下"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(574, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Erratic Blaster",
                    English = "Erratic Blaster",
                    French = "Électrochoc imprévisible",
                    German = "Erratischer Puls",
                    Japanese = "エラティックブラスター"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(575, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Static Charge",
                    English = "Static Charge",
                    French = "Charge statique",
                    German = "Statische Ladung",
                    Japanese = "帯電"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(576, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Lightning Resistance Down",
                    English = "Lightning Resistance Down",
                    French = "Résistance à la foudre réduite",
                    German = "Blitzresistenz -",
                    Japanese = "雷属性耐性低下"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(577, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Barofield",
                    English = "Barofield",
                    French = "Barotraumatisme",
                    German = "Baro-Feld",
                    Japanese = "バロフィールド"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(578, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "In the Headlights",
                    English = "In the Headlights",
                    French = "À portée de tête",
                    German = "Hauptkopf",
                    Japanese = "メインヘッド耐性低下"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(579, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Critical Strikes",
                    English = "Critical Strikes",
                    French = "Coups critiques",
                    German = "Kritische Attacke",
                    Japanese = "クリティカル攻撃"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(580, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Aetherochemical Nanospores α",
                    English = "Aetherochemical Nanospores α",
                    French = "Magismoparticules α",
                    German = "Nanosporen α",
                    Japanese = "魔科学粒子α"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(581, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Aetherochemical Nanospores β",
                    English = "Aetherochemical Nanospores β",
                    French = "Magismoparticules β",
                    German = "Nanosporen β",
                    Japanese = "魔科学粒子β"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(582, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Magic Vulnerability Down",
                    English = "Magic Vulnerability Down",
                    French = "Vulnérabilité magique diminuée",
                    German = "Verringerte Magie-Verwundbarkeit",
                    Japanese = "被魔法ダメージ軽減"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(583, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Physical Vulnerability Down",
                    English = "Physical Vulnerability Down",
                    French = "Vulnérabilité physique diminuée",
                    German = "Verringerte physische Verwundbarkeit",
                    Japanese = "被物理ダメージ軽減"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(584, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Energy Field",
                    English = "Energy Field",
                    French = "Champ défensif",
                    German = "Abwehrfeld",
                    Japanese = "防御フィールド"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(585, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Energy Field Down",
                    English = "Energy Field Down",
                    French = "Anti-champ défensif",
                    German = "Anti-Abwehrfeld",
                    Japanese = "対防御フィールド"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(586, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "HP Boost",
                    English = "HP Boost",
                    French = "Bonus de PV",
                    German = "LP-Bonus",
                    Japanese = "最大ＨＰアップ"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(587, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Forked Lightning",
                    English = "Forked Lightning",
                    French = "Éclair ramifié",
                    German = "Gabelblitz",
                    Japanese = "フォークライトニング"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(588, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Revelation Resistance Down",
                    English = "Revelation Resistance Down",
                    French = "Résistance à Révélation réduite",
                    German = "Offenbarungs-Resistenz -",
                    Japanese = "リヴァレーション耐性低下"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(589, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Chain of Purgatory",
                    English = "Chain of Purgatory",
                    French = "Souffle du purgatoire",
                    German = "Kette der Purgation",
                    Japanese = "誘爆"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(590, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Arm of Purgatory",
                    English = "Arm of Purgatory",
                    French = "Bras du purgatoire",
                    German = "Arm der Purgation",
                    Japanese = "延焼"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(591, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Bluefire",
                    English = "Bluefire",
                    French = "Flamme bleue",
                    German = "Blaufeuer",
                    Japanese = "青碧の炎"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(592, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Ring of Fire",
                    English = "Ring of Fire",
                    French = "Vortex de feu",
                    German = "Flammenwand",
                    Japanese = "炎渦"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(593, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Rise of the Phoenix",
                    English = "Rise of the Phoenix",
                    French = "Oiseau de feu",
                    German = "Feuervogel",
                    Japanese = "不死鳥"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(594, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Harvest",
                    English = "Harvest",
                    French = "Buveur d'âme",
                    German = "Seelensog",
                    Japanese = "吸魂"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(595, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Cloak of Death",
                    English = "Cloak of Death",
                    French = "Remous de la vie",
                    German = "Sog der Verzehrung",
                    Japanese = "霊泉禍"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(596, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Suffocated Will",
                    English = "Suffocated Will",
                    French = "Aura du Dragon-dieu",
                    German = "Drachenopfer",
                    Japanese = "龍圧"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(597, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Flare Dampening",
                    English = "Flare Dampening",
                    French = "ParaTéraBrasier",
                    German = "Neurolink",
                    Japanese = "拘束装置"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(598, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "(仮)物理シールド(ストンスキン)",
                    English = "(仮)物理シールド(ストンスキン)",
                    French = "(仮)物理シールド(ストンスキン)",
                    German = "(仮)物理シールド(ストンスキン)",
                    Japanese = "(仮)物理シールド(ストンスキン)"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(599, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "(仮)魔法シールド(ストンスキン)",
                    English = "(仮)魔法シールド(ストンスキン)",
                    French = "(仮)魔法シールド(ストンスキン)",
                    German = "(仮)魔法シールド(ストンスキン)",
                    Japanese = "(仮)魔法シールド(ストンスキン)"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(600, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "魔法受伤减轻",
                    English = "Magic Vulnerability Down",
                    French = "Vulnérabilité magique diminuée",
                    German = "Verringerte Magie-Verwundbarkeit",
                    Japanese = "被魔法ダメージ軽減"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(601, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Physical Vulnerability Down",
                    English = "Physical Vulnerability Down",
                    French = "Vulnérabilité physique diminuée",
                    German = "Verringerte physische Verwundbarkeit",
                    Japanese = "被物理ダメージ軽減"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(602, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Curse of the Mummy",
                    English = "Curse of the Mummy",
                    French = "Malédiction d'Azeyma",
                    German = "Azeymas Fluch",
                    Japanese = "アーゼマの呪い"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(603, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Mummification",
                    English = "Mummification",
                    French = "Pion d'Azeyma",
                    German = "Azeymas Jünger",
                    Japanese = "アーゼマの使徒"
                },
                CompanyAction = true,
            });
            StatusEffects.Add(604, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Thin Ice",
                    English = "Thin Ice",
                    French = "Verglas",
                    German = "Glatteis",
                    Japanese = "氷床"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(605, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Frostbite",
                    English = "Frostbite",
                    French = "Gelure",
                    German = "Erfrierung",
                    Japanese = "凍傷"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(606, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Frozen",
                    English = "Frozen",
                    French = "Glaciation",
                    German = "Überfroren",
                    Japanese = "凍結"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(607, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Snowball",
                    English = "Snowball",
                    French = "Boule de neige",
                    German = "Schneeball",
                    Japanese = "雪玉"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(608, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Death Throes",
                    English = "Death Throes",
                    French = "Affres de la mort",
                    German = "Agonales Klammern",
                    Japanese = "道連れ"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(609, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Seized",
                    English = "Seized",
                    French = "Étreinte mortelle",
                    German = "Umschlungen",
                    Japanese = "捕獲"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(610, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Petrification",
                    English = "Petrification",
                    French = "Pétrification",
                    German = "Stein",
                    Japanese = "石化"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(611, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Invigoration",
                    English = "Invigoration",
                    French = "Bonne humeur",
                    German = "Schwippdischwapp",
                    Japanese = "気分上々"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(612, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Wet Plate",
                    English = "Wet Plate",
                    French = "Plein d'eau",
                    German = "Vollgelaufen",
                    Japanese = "うるおい"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(613, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Imp",
                    English = "Imp",
                    French = "Kappa",
                    German = "Flusskobold",
                    Japanese = "カッパ"
                },
                CompanyAction = true,
            });
            StatusEffects.Add(614, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Hidden",
                    English = "Hidden",
                    French = "Dissimulation",
                    German = "Versteckt",
                    Japanese = "かくれる"
                },
                CompanyAction = true,
            });
            StatusEffects.Add(615, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Hidden",
                    English = "Hidden",
                    French = "Dissimulation",
                    German = "Versteckt",
                    Japanese = "かくれる"
                },
                CompanyAction = true,
            });
            StatusEffects.Add(616, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Invisible",
                    English = "Invisible",
                    French = "Invisible",
                    German = "Unsichtbar",
                    Japanese = "インビジブル"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(617, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Irradiated",
                    English = "Irradiated",
                    French = "Irradiation",
                    German = "Erstrahlend",
                    Japanese = "帯光"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(618, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Area of Influence Up",
                    English = "Area of Influence Up",
                    French = "Aire d'effet augmentée",
                    German = "Erweiterter Radius",
                    Japanese = "アクション効果範囲拡大"
                },
                CompanyAction = true,
            });
            StatusEffects.Add(619, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Burns",
                    English = "Burns",
                    French = "Brûlure",
                    German = "Brandwunde",
                    Japanese = "火傷"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(620, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Pacification",
                    English = "Pacification",
                    French = "Pacification",
                    German = "Pacem",
                    Japanese = "ＷＳ不可"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(621, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Fire Resistance Down",
                    English = "Fire Resistance Down",
                    French = "Résistance au feu diminuée",
                    German = "Feuerresistenz -",
                    Japanese = "火属性耐性低下"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(622, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Rotting Lungs",
                    English = "Rotting Lungs",
                    French = "Gaz putride",
                    German = "Verrottende Lunge",
                    Japanese = "ロットガス"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(623, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Disease",
                    English = "Disease",
                    French = "Maladie",
                    German = "Krankheit",
                    Japanese = "病気"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(624, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Flesh Wound",
                    English = "Flesh Wound",
                    French = "Blessure physique",
                    German = "Fleischwunde",
                    Japanese = "切傷"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(625, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Down for the Count",
                    English = "Down for the Count",
                    French = "Au tapis",
                    German = "Am Boden",
                    Japanese = "ノックダウン"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(626, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Out of the Action",
                    English = "Out of the Action",
                    French = "Actions bloquées",
                    German = "Außer Gefecht",
                    Japanese = "アクション実行不可"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(627, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Regen",
                    English = "Regen",
                    French = "Récup",
                    German = "Regena",
                    Japanese = "リジェネ"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(628, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Medica II",
                    English = "Medica II",
                    French = "Extra Médica",
                    German = "Resedra",
                    Japanese = "メディカラ"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(629, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Febrile",
                    English = "Febrile",
                    French = "Infirmité",
                    German = "Fiebrig",
                    Japanese = "虚弱"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(636, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Brand of the Sullen",
                    English = "Brand of the Sullen",
                    French = "Marque de la désolation",
                    German = "Mal des Leids",
                    Japanese = "悲嘆の烙印"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(637, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Brand of the Ireful",
                    English = "Brand of the Ireful",
                    French = "Marque de la fureur",
                    German = "Mal des Zorns",
                    Japanese = "憤怒の烙印"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(638, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Vulnerability Up",
                    English = "Vulnerability Up",
                    French = "Vulnérabilité augmentée",
                    German = "Erhöhte Verwundbarkeit",
                    Japanese = "被ダメージ上昇"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(639, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Pyretic",
                    English = "Pyretic",
                    French = "Pyromanie",
                    German = "Pyretisch",
                    Japanese = "ヒート"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(640, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Poison Resistance Up",
                    English = "Poison Resistance Up",
                    French = "Résistance au poison accrue",
                    German = "Giftresistenz +",
                    Japanese = "毒耐性向上"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(642, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Bleeding",
                    English = "Bleeding",
                    French = "Saignant",
                    German = "Blutung",
                    Japanese = "ペイン"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(643, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Bleeding",
                    English = "Bleeding",
                    French = "Saignant",
                    German = "Blutung",
                    Japanese = "ペイン"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(644, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Chicken",
                    English = "Chicken",
                    French = "Poulet",
                    German = "Huhn",
                    Japanese = "ニワトリ"
                },
                CompanyAction = true,
            });
            StatusEffects.Add(645, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Digesting",
                    English = "Digesting",
                    French = "Digestion",
                    German = "Verdauung",
                    Japanese = "消化中"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(646, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Abandonment",
                    English = "Abandonment",
                    French = "Isolement",
                    German = "Verlassen",
                    Japanese = "孤独感"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(647, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Atrophy",
                    English = "Atrophy",
                    French = "Épuisement",
                    German = "Atrophie",
                    Japanese = "フィジカルダウン"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(648, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Rehabilitation",
                    English = "Rehabilitation",
                    French = "Récup",
                    German = "Rehabilitation",
                    Japanese = "徐々にＨＰ回復"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(649, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Attack Up",
                    English = "Attack Up",
                    French = "Bonus d'attaque",
                    German = "Attacke-Bonus",
                    Japanese = "物理攻撃力アップ"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(650, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Attack Magic Potency Up",
                    English = "Attack Magic Potency Up",
                    French = "Bonus de puissance magique",
                    German = "Offensivmagie-Bonus",
                    Japanese = "魔法攻撃力アップ"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(651, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Haste",
                    English = "Haste",
                    French = "Hâte",
                    German = "Hast",
                    Japanese = "ヘイスト"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(652, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "HP & MP Boost",
                    English = "HP & MP Boost",
                    French = "Bonus de PV et PM",
                    German = "LP-/MP-Bonus",
                    Japanese = "最大ＨＰアップ＆最大ＭＰアップ"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(653, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Battle High",
                    English = "Battle High",
                    French = "Ivresse du combat",
                    German = "Euphorie",
                    Japanese = "戦意高揚"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(654, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Battle Fever",
                    English = "Battle Fever",
                    French = "Fièvre du combat",
                    German = "Raserei",
                    Japanese = "戦意高揚［強］"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(655, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Aegis Boon",
                    English = "Aegis Boon",
                    French = "Égide",
                    German = "Ägidensegen",
                    Japanese = "イージスブーン"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(656, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Invincibility",
                    English = "Invincibility",
                    French = "Invulnérable",
                    German = "Unverwundbar",
                    Japanese = "無敵"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(657, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Physical Vulnerability Up",
                    English = "Physical Vulnerability Up",
                    French = "Vulnérabilité physique augmentée",
                    German = "Erhöhte physische Verwundbarkeit",
                    Japanese = "被物理ダメージ増加"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(658, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Magic Vulnerability Up",
                    English = "Magic Vulnerability Up",
                    French = "Vulnérabilité magique augmentée",
                    German = "Erhöhte Magie-Verwundbarkeit",
                    Japanese = "被魔法ダメージ増加"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(659, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Blight",
                    English = "Blight",
                    French = "Supplice",
                    German = "Pesthauch",
                    Japanese = "クラウダ"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(660, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Extend",
                    English = "Extend",
                    French = "Prolongation",
                    German = "Zeitdehnung",
                    Japanese = "エテンド"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(661, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Double",
                    English = "Double",
                    French = "Double",
                    German = "Doppel",
                    Japanese = "ダブル"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(662, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Triple",
                    English = "Triple",
                    French = "Triple",
                    German = "Tripel",
                    Japanese = "トリプル"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(664, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Prey",
                    English = "Prey",
                    French = "Marquage",
                    German = "Markiert",
                    Japanese = "マーキング"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(665, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Slippery Prey",
                    English = "Slippery Prey",
                    French = "Marquage impossible",
                    German = "Unmarkierbar",
                    Japanese = "マーキング対象外"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(666, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "感電",
                    English = "感電",
                    French = "感電",
                    German = "感電",
                    Japanese = "感電"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(667, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Fetters",
                    English = "Fetters",
                    French = "Attache",
                    German = "Gefesselt",
                    Japanese = "拘束"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(668, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Fetters",
                    English = "Fetters",
                    French = "Attache",
                    German = "Gefesselt",
                    Japanese = "拘束"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(669, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Movement Speed Up",
                    English = "Movement Speed Up",
                    French = "Vitesse de déplacement accrue",
                    German = "Geschwindigkeit +",
                    Japanese = "移動速度上昇"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(670, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "Fire Resistance Down",
                    English = "Fire Resistance Down",
                    French = "Résistance au feu diminuée",
                    German = "Feuerresistenz -",
                    Japanese = "火属性耐性低下"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(671, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "无敌",
                    English = "Invincibility",
                    French = "Invulnérable",
                    German = "Unverwundbar",
                    Japanese = "無敵"
                },
                CompanyAction = false,
            });
            StatusEffects.Add(672, new StatusItem
            {
                Name = new StatusLocalization
                {
                    Chinese = "伤害上升",
                    English = "Damage Up",
                    French = "Bonus de dégâts",
                    German = "Schaden +",
                    Japanese = "ダメージ上昇"
                },
                CompanyAction = false,
            });
        }
    }
}
