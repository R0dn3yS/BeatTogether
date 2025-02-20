﻿using System.Collections.Generic;
using System.Linq;
using BeatTogether.Models;
using IPA.Config.Stores.Attributes;
using IPA.Config.Stores.Converters;

namespace BeatTogether
{
    public class Config
    {
        // Official master server name that will be seen by players
        public const string OfficialServerName = "Official Servers";

        // BeatTogether master server config
        public const string BeatTogetherServerName = "BeatTogether";
        public const string BeatTogetherHostName = "bs.dfagaming.nl";
        public const string BeatTogetherStatusUri = "http://bs.dfagaming.nl/status";
        public const int BeatTogetherMaxPartySize = 100;

        public virtual string SelectedServer { get; set; } = BeatTogetherServerName;

        [NonNullable, UseConverter(typeof(CollectionConverter<ServerDetails, List<ServerDetails?>>))]
        public virtual List<ServerDetails> Servers { get; set; } = new List<ServerDetails>();

        public virtual void OnReload()
        {
            if (Servers.All(server => server.ServerName != BeatTogetherServerName))
                Servers.Insert(0, new ServerDetails
                {
                    ServerName = BeatTogetherServerName,
                    HostName = BeatTogetherHostName,
                    StatusUri = BeatTogetherStatusUri,
                    MaxPartySize = BeatTogetherMaxPartySize
                });
        }

        public virtual void CopyFrom(Config other)
        {
            SelectedServer = other.SelectedServer;
            Servers = other.Servers;
        }
    }
}
