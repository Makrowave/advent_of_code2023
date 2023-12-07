namespace day7;

public class Hand : IComparable<Hand>
{
    public string Cards { get; init; }
    public int Rank { get; set; }
    public Type HandType { get; set; }
    public int[] HandHighCard { get; init; }
    public int Bid { get; init; }

    public Hand(string cards, int bid)
    {
        HandHighCard = new int[5];
        Cards = cards;
        Bid = bid;
        DetermineType();
        for (int i = 0; i < 5; i++)
        {
            HandHighCard[i] = CharToStrength(Cards[i]);
        }
    }
    

    private void DetermineType()
    {
        var chars = Cards.Select(
                chr => (
                    chr, 
                    Cards.Count(c => c == chr)
                    )
                )
            .DistinctBy(pair => pair.chr)
            .ToList();
        chars.Sort((
            el1, el2) 
            => el1.Item2.CompareTo(el2.Item2));
        if (chars.Count() == 5)
        {
            HandType = Type.HighCard;
        }
        else if (chars.Count() == 4)
        {
            HandType = Type.OnePair;
        }
        else if (chars.Count() == 3)
        {
            if (chars[2].Item2 == 3)
            {
                HandType = Type.ThreeOfAKind;
            }
            else
            {
                HandType = Type.TwoPair;
            }
        }
        else if (chars.Count() == 2)
        {
            if (chars[1].Item2 == 4)
            {
                HandType = Type.FourOfAKind;
            }
            else
            {
                HandType = Type.FullHouse;
            }
        }
        else if (chars.Count() == 1)
        {
            HandType = Type.FiveOfAKind;
        }
    }
    private int CharToStrength(char c)
    {
        switch (c)
        {
            case 'A':
                return (int)CardStrength.A;
            case 'K':
                return (int)CardStrength.K;
            case 'Q':
                return (int)CardStrength.Q;
            case 'J':
                return (int)CardStrength.J;
            case 'T':
                return (int)CardStrength.T;
        }
        if (c >= '0' && c <= '9')
            return c - '0';
        return 0;
    }

    public int CompareTo(Hand? other)
    {
        if (HandType < other.HandType)
            return -1;
        if (HandType > other.HandType)
            return 1;
        for (int i = 0; i < 5; i++)
        {
            if (HandHighCard[i] < other.HandHighCard[i])
                return -1;
            if (HandHighCard[i] > other.HandHighCard[i])
                return 1;
        }
        return 0;
    }
}