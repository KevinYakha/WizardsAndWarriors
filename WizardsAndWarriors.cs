using System;

abstract class Character
{
    protected Character(string characterType)
    {
        _characterType = characterType;
    }

    public abstract int DamagePoints(Character target);

    public virtual bool Vulnerable()
    {
        return false;
    }

    public override string ToString()
    {
        return "Character is a " + _characterType;
    }

    private string _characterType;
}

class Warrior : Character
{
    public Warrior() : base("Warrior") { }

    public override int DamagePoints(Character target) // 6 dmg regular 10 if vulnerable
    {
        // characters are generally not vulnerable, only wizards are if no spell was prepared
        return target.Vulnerable() ? 10 : 6;
    }
}

class Wizard : Character
{
    public Wizard() : base("Wizard") { }

    public override int DamagePoints(Character target) // 12 dmg if prepared spell, 3 if not
    {
        return _spellPrepared ? 12 : 3;
    }

    public void PrepareSpell()
    {
        _spellPrepared = true;
    }

    public override bool Vulnerable()
    {
        return !_spellPrepared;
    }

    private bool _spellPrepared = false;
}
