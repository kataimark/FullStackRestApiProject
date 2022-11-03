using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GBJ0CK_HFT_2021222.Models
{
    public class LolPlayer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(240)]
        public string Name { get; set; }
        [Range(0, 100)]
        public int Age { get; set; }
        [StringLength(240)]
        public string Role { get; set; }


        [ForeignKey(nameof(LolTeam))]
        public int LolTeam_id { get; set; }

        public virtual LolTeam LolTeam { get; set; }

        public LolPlayer()
        {

        }
        public LolPlayer(string line)
        {
            string[] split = line.Split('#');
            Id = int.Parse(split[0]);
            LolTeam_id = int.Parse(split[1]);
            Name = split[2];
            Age = int.Parse(split[3]);
            Role = split[4];
            
        }
    }
}
