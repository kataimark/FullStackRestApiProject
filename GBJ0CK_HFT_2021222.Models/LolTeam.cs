using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GBJ0CK_HFT_2021222.Models
{
    [Table("LolTeam")]
    public class LolTeam
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(240)]
        public string TeamName { get; set; }
        [Range(0, 100)]
        public int Wins { get; set; }
        [Range(0, 100)]
        public int WasChampion { get; set; }



        [ForeignKey(nameof(LolManager))]
        public int LolManager_id { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual LolManager LolManager { get; set; }

        public virtual ICollection<LolPlayer> LolPlayers { get; set; }

        public LolTeam()
        {
            LolPlayers = new HashSet<LolPlayer>();
        }

    }
}
