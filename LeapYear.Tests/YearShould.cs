using FluentAssertions;
using Xunit;

namespace LeapYear.Tests;

public class YearShould
{
    [Theory]
    [InlineData(1901)]
    [InlineData(1909)]
    [InlineData(1943)]
    [InlineData(1997)]
    public void NotBeALeapYearIfItIsNotDivisibleBy4(int input)
    {
        // arrange
        var sut = new Year(input);
        
        // act
        bool actual = sut.IsLeap();

        // assert
        actual.Should().BeFalse();
    }
    
    [Theory]
    [InlineData(1904)]
    [InlineData(1908)]
    [InlineData(1940)]
    [InlineData(1996)]
    public void BeALeapYearIfItIsDivisibleBy4(int input)
    {
        // arrange
        var sut = new Year(input);
        
        // act
        bool actual = sut.IsLeap();

        // assert
        actual.Should().BeTrue();
    }
    
    [Theory]
    [InlineData(1200)]
    [InlineData(1600)]
    [InlineData(2000)]
    [InlineData(2400)]
    public void BeALeapYearIfDivisibleBy400(int input)
    {
        // arrange
        var sut = new Year(input);
        
        // act
        bool actual = sut.IsLeap();

        // assert
        actual.Should().BeTrue();
    }
    
    [Theory]
    [InlineData(1400)]
    [InlineData(1700)]
    [InlineData(1800)]
    [InlineData(1900)]
    public void NotBeALeapYearIfItIsDivisibleBy100AndNotDivisibleBy400(int input)
    {
        // arrange
        var sut = new Year(input);
        
        // act
        bool actual = sut.IsLeap();

        // assert
        actual.Should().BeFalse();
    }
    
    [Theory]
    [InlineData(1584, 1588, 1592, 1596, 1600, 1604, 1608, 1612, 1616, 1620, 1624, 1628, 1632, 1636, 1640, 1644, 1648, 1652, 1656, 1660, 1664, 1668, 1672, 1676, 1680, 1684, 1688, 1692, 1696, 1704, 1708, 1712, 1716, 1720, 1724, 1728, 1732, 1736, 1740, 1744, 1748, 1752, 1756, 1760, 1764, 1768, 1772, 1776, 1780, 1784, 1788, 1792, 1796, 1804, 1808, 1812, 1816, 1820, 1824, 1828, 1832, 1836, 1840, 1844, 1848, 1852, 1856, 1860, 1864, 1868, 1872, 1876, 1880, 1884, 1888, 1892, 1896, 1904, 1908, 1912, 1916, 1920, 1924, 1928, 1932, 1936, 1940, 1944, 1948, 1952, 1956, 1960, 1964, 1968, 1972, 1976, 1980, 1984, 1988, 1992, 1996, 2000, 2004, 2008, 2012, 2016, 2020, 2024, 2028, 2032, 2036, 2040, 2044, 2048, 2052, 2056, 2060, 2064, 2068, 2072, 2076, 2080, 2084, 2088, 2092, 2096, 2104, 2108, 2112, 2116, 2120, 2124, 2128, 2132, 2136, 2140, 2144, 2148, 2152, 2156, 2160, 2164, 2168, 2172, 2176, 2180, 2184, 2188, 2192, 2196, 2204, 2208, 2212, 2216, 2220, 2224, 2228, 2232, 2236, 2240, 2244, 2248, 2252, 2256, 2260, 2264, 2268, 2272, 2276, 2280, 2284, 2288, 2292, 2296, 2304, 2308, 2312, 2316, 2320, 2324, 2328, 2332, 2336, 2340, 2344, 2348, 2352, 2356, 2360, 2364, 2368, 2372, 2376, 2380, 2384, 2388, 2392, 2396, 2400, 2404, 2408, 2412, 2416, 2420, 2424, 2428, 2432, 2436, 2440, 2444, 2448, 2452, 2456, 2460, 2464, 2468, 2472, 2476, 2480, 2484, 2488, 2492, 2496)]
    public void BeALeapYearForLeapYearsFrom1583To2500(params int[] years)
    {
        // arrange
        
        // act & assert
        foreach (int year in years)
        {
            var sut = new Year(year);
            bool actual = sut.IsLeap();
            actual.Should().BeTrue($"{year} is a leap year");
        }
    }
    
    [Fact]
    public void NotBeALeapYearForNonLeapYearsFrom1583To2500()
    {
        // arrange
        int[] leapYears = new[]
        {
            1584, 1588, 1592, 1596, 1600, 1604, 1608, 1612, 1616, 1620, 1624, 1628, 1632, 1636, 1640, 1644, 1648, 1652,
            1656, 1660, 1664, 1668, 1672, 1676, 1680, 1684, 1688, 1692, 1696, 1704, 1708, 1712, 1716, 1720, 1724, 1728,
            1732, 1736, 1740, 1744, 1748, 1752, 1756, 1760, 1764, 1768, 1772, 1776, 1780, 1784, 1788, 1792, 1796, 1804,
            1808, 1812, 1816, 1820, 1824, 1828, 1832, 1836, 1840, 1844, 1848, 1852, 1856, 1860, 1864, 1868, 1872, 1876,
            1880, 1884, 1888, 1892, 1896, 1904, 1908, 1912, 1916, 1920, 1924, 1928, 1932, 1936, 1940, 1944, 1948, 1952,
            1956, 1960, 1964, 1968, 1972, 1976, 1980, 1984, 1988, 1992, 1996, 2000, 2004, 2008, 2012, 2016, 2020, 2024,
            2028, 2032, 2036, 2040, 2044, 2048, 2052, 2056, 2060, 2064, 2068, 2072, 2076, 2080, 2084, 2088, 2092, 2096,
            2104, 2108, 2112, 2116, 2120, 2124, 2128, 2132, 2136, 2140, 2144, 2148, 2152, 2156, 2160, 2164, 2168, 2172,
            2176, 2180, 2184, 2188, 2192, 2196, 2204, 2208, 2212, 2216, 2220, 2224, 2228, 2232, 2236, 2240, 2244, 2248,
            2252, 2256, 2260, 2264, 2268, 2272, 2276, 2280, 2284, 2288, 2292, 2296, 2304, 2308, 2312, 2316, 2320, 2324,
            2328, 2332, 2336, 2340, 2344, 2348, 2352, 2356, 2360, 2364, 2368, 2372, 2376, 2380, 2384, 2388, 2392, 2396,
            2400, 2404, 2408, 2412, 2416, 2420, 2424, 2428, 2432, 2436, 2440, 2444, 2448, 2452, 2456, 2460, 2464, 2468,
            2472, 2476, 2480, 2484, 2488, 2492, 2496
        };
        
        // act & assert
        for (int year = 1583; year <= 2500; year++)
        {
            if (leapYears.Contains(year))
            {
                continue;
            }
            
            var sut = new Year(year);
            bool actual = sut.IsLeap();
            actual.Should().BeFalse($"{year} is not a leap year");
        }
    }
}