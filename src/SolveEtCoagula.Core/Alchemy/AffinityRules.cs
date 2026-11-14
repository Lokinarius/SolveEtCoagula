namespace SolveEtCoagula.Core.Alchemy;

// Regras do ciclo: Enxofre vence Mercúrio, Mercúrio vence Sal, Sal vence Enxofre.
public static class AffinityRules
{
    // Verdadeiro se a essência do atacante vence a afinidade do alvo.
    public static bool Beats(Essence attacker, Essence target) => (attacker, target) switch
    {
        (Essence.Sulfur, Essence.Mercury) => true,
        (Essence.Mercury, Essence.Salt) => true,
        (Essence.Salt, Essence.Sulfur) => true,
        _ => false
    };

    // Vence: efeito dobrado. Mesma afinidade: efeito pela metade. Outros casos: normal.
    public static double Multiplier(Essence used, Essence enemyAffinity)
    {
        if (Beats(used, enemyAffinity)) return 2.0;
        if (used == enemyAffinity) return 0.5;
        return 1.0;
    }
}