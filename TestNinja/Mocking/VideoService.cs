﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using Newtonsoft.Json;
using TestNinja.UnitTests.Mocking;

namespace TestNinja.Mocking {
    public class VideoService {
        private IVideoRepository _videoRepository;
        private IFileReader _fileReader;

        public VideoService(IFileReader fileReader = null, IVideoRepository videoRepository = null) {
            this._fileReader = fileReader ?? new FileReader();
            this._videoRepository = videoRepository ?? new VideoRepository();
        }

        public string ReadVideoTitle() {
            var str = _fileReader.Read("video.txt");
            var video = JsonConvert.DeserializeObject<Video>(str);
            if (video == null)
                return "Error parsing the video.";
            return video.Title;
        }

        public string GetUnprocessedVideosAsCsv() {
            var videoIds = new List<int>();

            var videos = _videoRepository.GetUnprocessedVideos();

            foreach (var v in videos)
                videoIds.Add(v.Id);

            return String.Join(",", videoIds);
        }
    }

    public class Video {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsProcessed { get; set; }
    }


    public class VideoContext : DbContext{
        public DbSet<Video> Videos { get; set; }
    }
}