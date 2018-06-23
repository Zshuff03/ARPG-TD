namespace ARPGTD.CharacterStats {
    ///This Enum is used for checking what kind of modifier is used
    ///Flat being an added value and percent being a percentage multiplier
    public enum StatModType {
        Flat = 100,
        PercentAdd = 200,
        PercentMult = 300,
    }

    ///StatModifier is a class built for use by the CharacterStats class
    ///These are used to handle buffs or debuffs to player stats
    public class StatModifier {
        public readonly float Value;                //Value of the modifier
        public readonly StatModType Type;           //Type of the modifier - See enum for types
        public readonly int Order;                  //Order in which to sort the modifier
        public readonly object Source;

        ///Creators
        ///Order is specified
        public StatModifier(float value, StatModType type, int order, object source) {
            Value = value;
            Type = type;
            Order = order;
            Source = source;
        }

        ///Order and Source not specified
        public StatModifier(float value, StatModType type) : this(value, type, (int)type, null) { }

        ///Source not specified
        public StatModifier(float value, StatModType type, int order) : this(value, type, order, null) { }

        ///Order not specified
        public StatModifier(float value, StatModType type, object source) : this(value, type, (int)type, source) { }
    }
}
