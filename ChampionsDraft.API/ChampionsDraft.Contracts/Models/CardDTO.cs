using System.Text.Json.Serialization;

namespace Contracts.Models;

// Root myDeserializedClass = JsonConvert.DeserializeObject<List<Root>>(myJsonResponse);

public class CardDTO
{
    [JsonPropertyName("pack_code")]
    public string PackCode { get; set; }

    [JsonPropertyName("pack_name")]
    public string PackName { get; set; }

    [JsonPropertyName("type_code")]
    public string TypeCode { get; set; }

    [JsonPropertyName("type_name")]
    public string TypeName { get; set; }

    [JsonPropertyName("faction_code")]
    public string FactionCode { get; set; }

    [JsonPropertyName("faction_name")]
    public string FactionName { get; set; }

    [JsonPropertyName("position")]
    public int Position { get; set; }

    [JsonPropertyName("code")]
    public string Code { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("real_name")]
    public string RealName { get; set; }

    [JsonPropertyName("subname")]
    public string Subname { get; set; }

    [JsonPropertyName("cost")]
    public int Cost { get; set; }

    [JsonPropertyName("text")]
    public string Text { get; set; }

    [JsonPropertyName("real_text")]
    public string RealText { get; set; }

    [JsonPropertyName("quantity")]
    public int Quantity { get; set; }

    [JsonPropertyName("resource_energy")]
    public int ResourceEnergy { get; set; }

    [JsonPropertyName("health")]
    public int Health { get; set; }

    [JsonPropertyName("health_per_hero")]
    public bool HealthPerHero { get; set; }

    [JsonPropertyName("attack")]
    public int Attack { get; set; }

    [JsonPropertyName("attack_cost")]
    public int AttackCost { get; set; }

    [JsonPropertyName("base_threat_fixed")]
    public bool BaseThreatFixed { get; set; }

    [JsonPropertyName("escalation_threat_fixed")]
    public bool EscalationThreatFixed { get; set; }

    [JsonPropertyName("threat_fixed")]
    public bool ThreatFixed { get; set; }

    [JsonPropertyName("deck_limit")]
    public int DeckLimit { get; set; }

    [JsonPropertyName("traits")]
    public string Traits { get; set; }

    [JsonPropertyName("real_traits")]
    public string RealTraits { get; set; }

    [JsonPropertyName("is_unique")]
    public bool IsUnique { get; set; }

    [JsonPropertyName("hidden")]
    public bool Hidden { get; set; }

    [JsonPropertyName("permanent")]
    public bool Permanent { get; set; }

    [JsonPropertyName("double_sided")]
    public bool DoubleSided { get; set; }

    [JsonPropertyName("octgn_id")]
    public string OctgnId { get; set; }

    [JsonPropertyName("attack_star")]
    public bool AttackStar { get; set; }

    [JsonPropertyName("thwart_star")]
    public bool ThwartStar { get; set; }

    [JsonPropertyName("defense_star")]
    public bool DefenseStar { get; set; }

    [JsonPropertyName("health_star")]
    public bool HealthStar { get; set; }

    [JsonPropertyName("recover_star")]
    public bool RecoverStar { get; set; }

    [JsonPropertyName("scheme_star")]
    public bool SchemeStar { get; set; }

    [JsonPropertyName("boost_star")]
    public bool BoostStar { get; set; }

    [JsonPropertyName("threat_star")]
    public bool ThreatStar { get; set; }

    [JsonPropertyName("escalation_threat_star")]
    public bool EscalationThreatStar { get; set; }

    [JsonPropertyName("url")]
    public string Url { get; set; }

    [JsonPropertyName("imagesrc")]
    public string Imagesrc { get; set; }

    [JsonPropertyName("resource_mental")]
    public int? ResourceMental { get; set; }

    [JsonPropertyName("thwart")]
    public int? Thwart { get; set; }

    [JsonPropertyName("thwart_cost")]
    public int? ThwartCost { get; set; }

    [JsonPropertyName("flavor")]
    public string Flavor { get; set; }

    [JsonPropertyName("duplicated_by")]
    public List<string> DuplicatedBy { get; set; }

    [JsonPropertyName("resource_physical")]
    public int? ResourcePhysical { get; set; }

    [JsonPropertyName("resource_wild")]
    public int? ResourceWild { get; set; }

    [JsonPropertyName("card_set_code")]
    public string CardSetCode { get; set; }

    [JsonPropertyName("card_set_name")]
    public string CardSetName { get; set; }

    [JsonPropertyName("card_set_type_name_code")]
    public string CardSetTypeNameCode { get; set; }

    [JsonPropertyName("set_position")]
    public int? SetPosition { get; set; }

    [JsonPropertyName("illustrator")]
    public string Illustrator { get; set; }

    [JsonPropertyName("duplicate_of_code")]
    public string DuplicateOfCode { get; set; }

    [JsonPropertyName("duplicate_of_name")]
    public string DuplicateOfName { get; set; }

    [JsonPropertyName("base_threat")]
    public int? BaseThreat { get; set; }

    [JsonPropertyName("errata")]
    public string Errata { get; set; }

    [JsonPropertyName("linked_to_code")]
    public string LinkedToCode { get; set; }

    [JsonPropertyName("linked_to_name")]
    public string LinkedToName { get; set; }

    [JsonPropertyName("hand_size")]
    public int? HandSize { get; set; }

    [JsonPropertyName("defense")]
    public int? Defense { get; set; }

    [JsonPropertyName("meta")]
    public MetaDTO Meta { get; set; }

    [JsonPropertyName("linked_card")]
    public LinkedCardDTO LinkedCard { get; set; }

    [JsonPropertyName("recover")]
    public int? Recover { get; set; }

    [JsonPropertyName("deck_requirements")]
    public List<DeckRequirementDTO> DeckRequirements { get; set; }

    [JsonPropertyName("deck_options")]
    public List<DeckOptionDTO> DeckOptions { get; set; }

    [JsonPropertyName("back_text")]
    public string BackText { get; set; }

    [JsonPropertyName("back_name")]
    public string BackName { get; set; }

    [JsonPropertyName("backimagesrc")]
    public string Backimagesrc { get; set; }

    [JsonPropertyName("scheme_acceleration")]
    public int? SchemeAcceleration { get; set; }

    [JsonPropertyName("scheme_hazard")]
    public int? SchemeHazard { get; set; }

    [JsonPropertyName("boost")]
    public int? Boost { get; set; }

    [JsonPropertyName("scheme_amplify")]
    public int? SchemeAmplify { get; set; }

    [JsonPropertyName("scheme")]
    public int? Scheme { get; set; }

    [JsonPropertyName("scheme_crisis")]
    public int? SchemeCrisis { get; set; }
}