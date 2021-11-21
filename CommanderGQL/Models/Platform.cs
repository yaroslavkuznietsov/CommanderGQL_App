using HotChocolate;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace CommanderGQL.Models
{
    //[GraphQLDescription("Repesents any software or service that has a command line interface.")] / использовалось для описания api voyager /
    public class Platform
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        //[GraphQLDescription("Reprents a purchased, valid license for the platform.")]
        public string LicenseKey { get; set; }

        public ICollection<Command> Commands { get; set; } = new List<Command>();
    }
}
