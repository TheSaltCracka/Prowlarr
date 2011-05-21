﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using NzbDrone.Core.Repository.Quality;
using SubSonic.SqlGeneration.Schema;

namespace NzbDrone.Core.Repository
{
    public class Series
    {
        [SubSonicPrimaryKey(false)]
        public virtual int SeriesId { get; set; }

        [SubSonicNullString]
        public string Title { get; set; }

        [SubSonicNullString]
        public string CleanTitle { get; set; }

        [SubSonicNullString]
        public string Status { get; set; }

        [SubSonicNullString]
        public string Overview { get; set; }

        [DisplayName("Air on")]
        public DayOfWeek? AirsDayOfWeek { get; set; }

        [SubSonicNullString]
        public String AirTimes { get; set; }

        [SubSonicNullString]
        public string Language { get; set; }

        public string Path { get; set; }

        public bool Monitored { get; set; }


        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Series"/> is hidden.
        /// </summary>
        /// <value><c>true</c> if hidden; otherwise, <c>false</c>.</value>
        /// <remarks>This field will be used for shows that are pending delete or 
        /// new series that haven't been successfully imported</remarks>
        public bool Hidden { get; set; }

        public virtual int QualityProfileId { get; set; }

        public bool SeasonFolder { get; set; }

        public DateTime? LastInfoSync { get; set; }

        public DateTime? LastDiskSync { get; set; }

        [SubSonicToOneRelation(ThisClassContainsJoinKey = true, JoinKeyName = "QualityProfileId")]
        public virtual QualityProfile QualityProfile { get; set; }

        [SubSonicToManyRelation]
        public virtual IList<Season> Seasons { get; protected set; }

        [SubSonicToManyRelation]
        public virtual IList<Episode> Episodes { get; set; }

        [SubSonicToManyRelation]
        public virtual IList<EpisodeFile> EpisodeFiles { get; protected set; }
    }
}