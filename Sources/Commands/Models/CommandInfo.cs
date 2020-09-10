using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Assistant.Facade.Commands;

namespace Assistant.Commands.Models
{
    public class CommandInfo : ICommandInfo
    {
        public int Priority { get; set; } = 0;

        [Required]
        public IEnumerable<IEnumerable<string>> Keys { get; set; } = new string[][] { };
    }
}
