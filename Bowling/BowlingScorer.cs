namespace Bowling;

public class BowlingScorer
{
    public int Calculate(string input)
    {
        const char strike = 'X';
        const char spare = '/';
        const char miss = '-';
        const int maxPins = 10;
        
        // parse the input
        var gameCard = new GameCardParser().Parse(input);
        
        // calculate the number of pins for each ball
        foreach (var frame in gameCard.Frames)
        {
            if (frame.Ball1.Code == strike)
            {
                frame.Ball1.NumberOfPins = maxPins;
                continue;
            }

            if (frame.Ball2.Code == spare)
            {
                frame.Ball1.NumberOfPins = ParseNumberOfPins(frame.Ball1.Code);
                frame.Ball2.NumberOfPins = maxPins - frame.Ball1.NumberOfPins;
                continue;
            }

            if (frame.Ball1.Code != miss)
            {
                frame.Ball1.NumberOfPins = ParseNumberOfPins(frame.Ball1.Code);
            }
            if (frame.Ball2.Code != miss)
            {
                frame.Ball2.NumberOfPins = ParseNumberOfPins(frame.Ball2.Code);
            }
        }
        
        // calculate the bonus balls
        if (gameCard.BonusBall1.Code == strike)
        {
            gameCard.BonusBall1.NumberOfPins = maxPins;
        }
        else if (gameCard.BonusBall1.Code != miss)
        {
            gameCard.BonusBall1.NumberOfPins = ParseNumberOfPins(gameCard.BonusBall1.Code);
        }
        
        if (gameCard.BonusBall2.Code == strike)
        {
            gameCard.BonusBall2.NumberOfPins = maxPins;
        }
        else if (gameCard.BonusBall2.Code != miss)
        {
            gameCard.BonusBall2.NumberOfPins = ParseNumberOfPins(gameCard.BonusBall2.Code);
        }

        // score each frame
        for (var index = 0; index < gameCard.FrameCount; index++)
        {
            var frame = gameCard.Frames[index];
            
            // strike
            if (frame.Ball1.Code == strike)
            {
                if (index == gameCard.FrameCount)
                {
                    frame.Score = maxPins + gameCard.BonusBall1.NumberOfPins + gameCard.BonusBall2.NumberOfPins;
                }
                else
                {
                    frame.Score = maxPins + NextTwoBallsNumberOfPins(gameCard, index);   
                }
            }
            // spare
            else if (frame.Ball2.Code == spare)
            {
                if (index == gameCard.FrameCount)
                {
                    frame.Score = maxPins + gameCard.BonusBall1.NumberOfPins;
                }
                else
                {
                    frame.Score = maxPins + NextBallNumberOfPins(gameCard, index);
                }
            }
            // normal
            else
            {
                frame.Score = frame.Ball1.NumberOfPins + frame.Ball2.NumberOfPins;   
            }
        }

        return gameCard.Frames.Sum(f => f.Score);
    }

    private int ParseNumberOfPins(char? input)
    {
        if (!input.HasValue)
        {
            return 0;
        }
        
        return int.Parse(input.ToString()!);
    }

    private int NextBallNumberOfPins(GameCardParser.GameCard gameCard, int currentFrameIndex)
    {
        return GetNextBallsNumberOfPins(gameCard, currentFrameIndex, 1);
    }
    
    private int NextTwoBallsNumberOfPins(GameCardParser.GameCard gameCard, int currentFrameIndex)
    {
        return GetNextBallsNumberOfPins(gameCard, currentFrameIndex, 2);
    }
    
    private int GetNextBallsNumberOfPins(GameCardParser.GameCard gameCard, int currentFrameIndex, int ballsRequired)
    {
        int result = 0;
        int resultCount = 0;
        
        // start at the next frame and find non-empty balls; accumulate resultCount NumberOfPins from the subsequent frames/balls 
        for (int index = currentFrameIndex + 1; index < gameCard.FrameCount; index++)
        {
            var frame = gameCard.Frames[index];
            if (frame.Ball1.Code.HasValue)
            {
                result += frame.Ball1.NumberOfPins;
                resultCount++;
            }
            
            if (resultCount < ballsRequired && frame.Ball2.Code.HasValue)
            {
                result += frame.Ball2.NumberOfPins;
                resultCount++;
            }

            if (resultCount >= ballsRequired)
            {
                return result;
            }
        }

        // if we still haven't accumulated enough balls, try the bonus balls as well 
        if (resultCount < ballsRequired && gameCard.BonusBall1.Code.HasValue)
        {
            result += gameCard.BonusBall1.NumberOfPins;
            resultCount++;
        }
        
        if (resultCount < ballsRequired && gameCard.BonusBall2.Code.HasValue)
        {
            result += gameCard.BonusBall2.NumberOfPins;
        }
        
        return result;
    }
}