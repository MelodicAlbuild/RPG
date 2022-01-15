using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IStats
{
    public int Attack { get; }
    public int Speed { get; }
    public int Health { get; }
    public int Defense { get; }
    public int Intelect { get; }
    public int Vitality { get; }
}
