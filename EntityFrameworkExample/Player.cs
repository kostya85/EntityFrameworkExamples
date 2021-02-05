using System;
using System.Collections.Generic;

using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkExample
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Position { get; set; }        
        public Player()
        {

        }
        public Player(string name, int age, string position)
        {
            Name = name;
            Age = age;
            Position = position;
        }
    }
}
