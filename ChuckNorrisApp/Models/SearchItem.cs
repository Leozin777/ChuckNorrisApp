using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChuckNorrisApp.Models;

public class SearchItem
{
    public int total { get; set; }
    public IEnumerable<Joke> result { get; set; }
}
