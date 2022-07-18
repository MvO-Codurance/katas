namespace Bowling;

public class BowlingScorer
{
    public int Calculate(string input)
    {
        // parse the game card
        var parser = new GameCardParser();
        var gameCard = parser.Parse(input);
        
        // calculate the number of pins for each ball
        for (var index = 0; index < gameCard.Frames.Count; index++)
        {
            var frame = gameCard.Frames[index];
            if (frame.Ball1.Code == 'X')
            {
                frame.Ball1.NumberOfPins = 10;
                continue;
            }
            if (frame.Ball2.Code == '/')
            {
                frame.Ball1.NumberOfPins = ParseNumberOfPins(frame.Ball1.Code);
                frame.Ball2.NumberOfPins = 10 - frame.Ball1.NumberOfPins;
                continue;
            }
            if (frame.Ball1.Code != '-')
            {
                frame.Ball1.NumberOfPins = ParseNumberOfPins(frame.Ball1.Code);
            }
            if (frame.Ball2.Code != '-')
            {
                frame.Ball2.NumberOfPins = ParseNumberOfPins(frame.Ball2.Code);
            }
        }
        
        // calculate the bonus balls
        if (gameCard.BonusBall1.Code == 'X')
        {
            gameCard.BonusBall1.NumberOfPins = 10;
        }
        else if (gameCard.BonusBall1.Code != '-')
        {
            gameCard.BonusBall1.NumberOfPins = ParseNumberOfPins(gameCard.BonusBall1.Code);
        }
        
        if (gameCard.BonusBall2.Code == 'X')
        {
            gameCard.BonusBall2.NumberOfPins = 10;
        }
        else if (gameCard.BonusBall2.Code != '-')
        {
            gameCard.BonusBall2.NumberOfPins = ParseNumberOfPins(gameCard.BonusBall2.Code);
        }

        // score each frame
        for (var index = 0; index < gameCard.Frames.Count; index++)
        {
            var frame = gameCard.Frames[index];
            var nextFrame = new GameCardParser.Frame();
            if (index + 1 < gameCard.Frames.Count)
            {
                nextFrame = gameCard.Frames[index + 1];
            }

            // strike
            if (frame.Ball1.Code == 'X')
            {
                if (index == gameCard.Frames.Count)
                {
                    frame.Score = 10 + gameCard.BonusBall1.NumberOfPins + gameCard.BonusBall2.NumberOfPins;
                }
                else
                {
                    frame.Score = 10 + GetNextBallsNumberOfPins(gameCard, index, 2); // nextFrame.Ball1.NumberOfPins + nextFrame.Ball2.NumberOfPins;   
                }
            }
            // spare
            else if (frame.Ball2.Code == '/')
            {
                if (index == gameCard.Frames.Count)
                {
                    frame.Score = 10 + gameCard.BonusBall1.NumberOfPins;
                }
                else
                {
                    frame.Score = 10 + GetNextBallsNumberOfPins(gameCard, index, 1); // nextFrame.Ball1.NumberOfPins;
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
        
        return int.Parse(input.ToString());
    }
    
    private int GetNextBallsNumberOfPins(GameCardParser.GameCard gameCard, int currentFrameIndex, int ballsRequired)
    {
        int result = 0;
        int resultCount = 0;
        
        // start at the next frame and find non-empty balls; accumulate resultCount NumberOfPins from the frames 
        for (int index = currentFrameIndex + 1; index < gameCard.Frames.Count; index++)
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