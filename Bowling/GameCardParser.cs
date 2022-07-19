namespace Bowling;

public class GameCardParser
{
    public GameCard Parse(string input)
    {
        if (input == null) throw new ArgumentNullException(nameof(input));
        
        const string bonusBallDelimiter = "||";
        const char frameDelimiter = '|';

        // parse bonus balls
        int framesStringEndPosition = input.IndexOf(bonusBallDelimiter, StringComparison.OrdinalIgnoreCase);
        string bonusBalls = input.Substring(framesStringEndPosition + 2);
        var bonusBall1 = new Ball();
        var bonusBall2 = new Ball();
        if (bonusBalls.Length > 0)
        {
            bonusBall1.Code = bonusBalls[0];
        }
        if (bonusBalls.Length > 1)
        {
            bonusBall2.Code = bonusBalls[1];
        }
        
        // parse frames
        string framesString = input.Substring(0, framesStringEndPosition);
        List<Frame> frames = new List<Frame>();
        foreach (string frameString in framesString.Split(frameDelimiter))
        {
            var frame = new Frame();
            frame.Ball1.Code = frameString[0];
            if (frameString.Length > 1)
            {
                frame.Ball2.Code = frameString[1];
            }
            
            frames.Add(frame);
        }
        
        return new GameCard(frames, bonusBall1, bonusBall2);
    }
    
    public class GameCard
    {
        public int FrameCount { get; }
        public IList<Frame> Frames { get; }
        public Ball BonusBall1 { get; set; }
        public Ball BonusBall2 { get; set; }

        public GameCard(IList<Frame> frames, Ball bonusBall1, Ball bonusBall2)
        {
            FrameCount = frames.Count();
            Frames = frames;
            BonusBall1 = bonusBall1;
            BonusBall2 = bonusBall2;
        }
    }

    public class Frame
    {
        public Ball Ball1 { get; set; } = new Ball();
        public Ball Ball2 { get; set; } = new Ball();
        public int Score { get; set; }

        public override string ToString()
        {
            return $"{Ball1.Code}{Ball2.Code}";
        }
    }

    public class Ball
    {
        public char? Code { get; set; } = null;
        public int NumberOfPins { get; set; } = 0;
    }
}