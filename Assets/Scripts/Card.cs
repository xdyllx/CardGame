using System.Collections.Generic;

public enum CardType
{
    UNKNOWN = 0,
    MOVE = 1,     // 移动卡
    RECOVER = 2,  // 恢复卡
    DEFEND = 3,   // 防御卡
    ATTACK = 4    // 攻击卡

}


public class Card
{
    public int Id { get; }
    public string Name { get; }
    public int MpCost { get; }

    virtual public CardType GetCardType()
    {
        return CardType.UNKNOWN;
    }

    public Card(int Id, string Name, int MpCost)
    {
        this.Id = Id;
        this.Name = Name;
        this.MpCost = MpCost;
    }

    virtual public string GetInfo()
    {
        return "";
    }
}


public class MoveCard : Card
{
    public int XMove { get; }
    public int YMove { get; }

    
    public override CardType GetCardType()
    {
        return CardType.MOVE;
    }

    public MoveCard(int Id, string Name, int MpCost, int XMove, int YMove) : base(Id, Name, MpCost)
    {
        this.XMove = XMove;
        this.YMove = YMove;
    }

    public override string GetInfo()
    {
        return "Id:" + Id.ToString() + ", MpCost:" + MpCost.ToString() + ", XMove:" + XMove.ToString() + ", YMove:" + YMove.ToString();
    }
}

public class RecoverCard : Card
{
    public int MpRecover { get; }


    public override CardType GetCardType()
    {
        return CardType.RECOVER;
    }

    public RecoverCard(int Id, string Name, int MpCost, int MpRecover) : base(Id, Name, MpCost)
    {
        {
            this.MpRecover = MpRecover;
        }
    }

    public override string GetInfo()
    {
        return "Id:" + Id.ToString() + ", MpCost:" + MpCost.ToString() + ", MpRecover:" + MpRecover.ToString();
    }
}

public class DefendCard : Card
{
    public int Defend { get; }

    public override CardType GetCardType()
    {
        return CardType.DEFEND;
    }

    public DefendCard(int Id, string Name, int MpCost, int Defend) : base(Id, Name, MpCost)
    {
        this.Defend = Defend;
    }

    public override string GetInfo()
    {
        return "Id:" + Id.ToString() + ", MpCost:" + MpCost.ToString() + ", Defend:" + Defend.ToString();
    }
}

public class AttackCard : Card
{
    public int Attack { get; }

    // 攻击范围 (-1,1)   (dx+1) + 3 * (dy-1)
    public HashSet<int> AttackRange { get; }

    public override CardType GetCardType()
    {
        return CardType.ATTACK;
    }

    public AttackCard(int Id, string Name, int MpCost, int Attack, HashSet<int> AttackRange) : base(Id, Name, MpCost)
    {
        this.Attack = Attack;
        this.AttackRange = AttackRange;
    }

    public override string GetInfo()
    {
        string attackRangeInfo = ", AttackRange:";
        foreach(var num in AttackRange)
        {
            attackRangeInfo = attackRangeInfo + num.ToString() + ";";
        }
        return "Id:" + Id.ToString() + ", MpCost:" + MpCost.ToString() + ", Attack:" + Attack.ToString() + attackRangeInfo;
    }
}
