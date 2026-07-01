using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Domain.Models
{
    public record JokeModel(string Type, string Setup, string Punchline, int Id);
}
