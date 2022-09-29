﻿using System.Threading.Tasks;
using shiki.Global_properties.Bases;
using shiki.Global_properties.Classes;
using Version = shiki.Global_properties.Bases.Version;

namespace shiki.Global_properties.UpdatableInformation
{
    public class Videos : ApiBase
    {
        public Videos(ApiClient apiClient) : base(Version.v1, apiClient)
        {
        }

        public async Task<Video> GetVideos(int id)
        {
            return await Request<Video>($"animes/{id}/videos");
        }

        public async Task<Video> PostVideo(int id, NewVideo video, AccessToken personalInformation)
        {
            return await SendJson<Video>($"animes/{id}/videos", video, personalInformation);
        }

        public async Task DeleteVideo(int a_id, int id, AccessToken personalInformation)
        {
            await NoResponseRequest($"animes/{a_id}/videos/{id}", personalInformation);
        }
    }
}