using System;
using System.Collections.Generic;
using System.Text;

namespace Lab9
{
    class Student
    {
        private string _name, _hometown;
        private int _wins, _draws, _defeats, _height, _weight;
        public static string orderedBy = "name";

        public Student(string name, string hometown, int height, int weight)
        {
            _name = name;
            _hometown = hometown;
            _wins = 0;
            _draws = 0;
            _defeats = 0;
            _height = height;
            _weight = weight;
        }
        public Student(string name, string hometown, int wins, int draws, int defeats, int height, int weight)
        {
            _name = name;
            _hometown = hometown;
            _wins = wins;
            _draws = draws;
            _defeats = defeats;
            _height = height;
            _weight = weight;
        }
        public void Rename(string name)
        {
            _name = name;
        }
        public string GetName()
        {
            return _name;
        }
        public string GetHometown()
        {
            return _hometown;
        }
        public int GetHeightValue()
        {
            return _height;
        }
        public string GetHeight()
        {
            var height = new StringBuilder();
            height.Append(_height / 12);
            height.Append("'");
            height.Append(_height % 12);
            height.Append("\"");

            return height.ToString();
        }
        public int GetWeightValue()
        {
            return _weight;
        }
        public string GetWeight()
        {
            var weight = new StringBuilder();
            weight.Append(_weight);
            weight.Append(" lbs.");

            return weight.ToString();
        }
        public int GetWins()
        {
            return _wins;
        }
        public int GetDraws()
        {
            return _draws;
        }
        public int GetDefeats()
        {
            return _defeats;
        }
        public int GetTotalMatches()
        {
            return _wins + _draws + _defeats;
        }
        public float GetWinRate()
        {
            if (GetTotalMatches() == 0) return 0;
            return (float)_wins / (float)GetTotalMatches() * 100;
        }
        public float GetDrawRate()
        {
            if (GetTotalMatches() == 0) return 0;
            return (float)_draws / (float)GetTotalMatches() * 100;
        }
        public float GetDefeatRate()
        {
            if (GetTotalMatches() == 0) return 0;
            return (float)_defeats / (float)GetTotalMatches() * 100;
        }
        public void AddWin()
        {
            _wins++;
        }
        public void AddDraw()
        {
            _draws++;
        }
        public void AddDefeat()
        {
            _defeats++;
        }
        public string GetSortValue()
        {
            switch (orderedBy)
            {
                case "name":
                    return GetName();
                case "wins":
                    return GetWins().ToString();
                case "draws":
                    return GetDraws().ToString();
                case "defeats":
                    return GetDefeats().ToString();
                case "hometown":
                    return GetHometown();
                case "height":
                    return GetHeight();
                case "weight":
                    return GetWeight();
                default:
                    return "Error: Unknown Parameter";
            }
        }
    }
}
