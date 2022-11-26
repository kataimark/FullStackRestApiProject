using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace GBJ0CK_HFT_2021222.Models
{
    [Table("LolPlayer")]
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
        [NotMapped]
        [JsonIgnore]
        public virtual LolTeam LolTeam { get; set; }

    }
}
