using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking {

    [TestFixture]
    class VideoServiceTests {


        private Mock<IFileReader> _mockFileReader;
        private Mock<IVideoRepository> _mockVideoRepository;
        private VideoService _service;

        [SetUp]
        public void SetUp()
        {
            _mockFileReader = new Mock<IFileReader>();
            _mockVideoRepository = new Mock<IVideoRepository>();
            _service = new VideoService(_mockFileReader.Object, _mockVideoRepository.Object);
        }

        [Test]
        public void ReadVideoTitle_EmptyFile_ReturnErrorMessage() {

            _mockFileReader.Setup(fr => fr.Read("video.txt")).Returns("");

            var result = _service.ReadVideoTitle();

            Assert.That(result, Does.Contain("error").IgnoreCase);
        }

        [Test]
        public void GetUnprocessedVideosAsCsv_AllVideosAreProcessed_ReturnEmptyString()
        {
            _mockVideoRepository.Setup(vr => vr.GetUnprocessedVideos()).Returns(new List<Video>());

            var result = _service.GetUnprocessedVideosAsCsv();

            Assert.That(result, Is.Empty);
        }

        [Test]
        public void GetUnprocessedVideosAsCsv_AFewVideosAreNotProcessed_ReturnStringWithIdsUnprocessedVideos() {

            var video1 = new Video() {Id = 1, IsProcessed = false};
            var video2= new Video() {Id = 2, IsProcessed = false};
            var video3 = new Video() {Id = 3, IsProcessed = false};

            _mockVideoRepository.Setup(vr => vr.GetUnprocessedVideos()).Returns(new List<Video>(){video1, video2, video3});

            var result = _service.GetUnprocessedVideosAsCsv();

            Assert.That(result, Is.EqualTo("1,2,3"));
        }
    }
}
