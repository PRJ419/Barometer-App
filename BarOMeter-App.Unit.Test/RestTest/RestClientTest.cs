using System;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Barometer_App.DTO;
using Barometer_App.Models;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NUnit.Framework;
using NUnit.Framework.Internal;
using RESTClient;

namespace BarOMeterApp.Unit.Test
{
    [TestFixture]
    class RestClientTest
    {
        [Test]
        public void DeleteBar_OK_ReceivesTrue()
        {
            var rc = new RestClient(new MockHttpMessageHandler(async (request, cancellationToken) =>
            {
                var responseMessage = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = null
                };

                return await Task.FromResult(responseMessage);
            }));

            Assert.That(rc.DeleteBar("TestBar").Result, Is.True);
        }

        [Test]
        public void DeleteBar_BadRequest_ReceivesFalse()
        {
            var rc = new RestClient(new MockHttpMessageHandler(async (request, cancellationToken) =>
            {
                var responseMessage = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = null
                };

                return await Task.FromResult(responseMessage);
            }));

            Assert.That(rc.DeleteBar("TestBar").Result, Is.False);
        }

        [Test]
        public void GetDetailedBar_OK_GoodBarname_ReceivesCorrect()
        {
            var Url = "good.url";

            var rc = new RestClient(new MockHttpMessageHandler(async (request, cancellationToken) =>
            {
                var responseMessage = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent("{ 'BarName':'TestBar'}")
                };

                return await Task.FromResult(responseMessage);
            }));
            
            Assert.That(rc.GetDetailedBar(Url).Result.BarName, Is.EqualTo("TestBar"));
        }

        [Test]
        public void GetDetailedBar_BadRequest_BadBarname_ReceivesNull()
        {
            var Url = "bad.url";

            var rc = new RestClient(new MockHttpMessageHandler(async (request, cancellationToken) =>
            {
                var responseMessage = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent("{ 'BarName':'TestBar'}")
                };

                return await Task.FromResult(responseMessage);
            }));

            Assert.That(rc.GetDetailedBar(Url).Result.BarName, Is.Null);
        }

        [Test]
        public void EditBar_OK_CorrectModelSent_ReturnsTrue()
        {
            var rc = new RestClient(new MockHttpMessageHandler(async (request, cancellationToken) =>
            {
                var responseMessage = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = null
                };

                return await Task.FromResult(responseMessage);
            }));

            Assert.That(rc.EditBar(new Bar()).Result, Is.True);
        }

        [Test]
        public void EditBar_BadRequest_WrongModelSent_ReturnsFalse()
        {
            var rc = new RestClient(new MockHttpMessageHandler(async (request, cancellationToken) =>
            {
                var responseMessage = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = null
                };

                return await Task.FromResult(responseMessage);
            }));

            Assert.That(rc.EditBar(new Bar()).Result, Is.False);
        }

        [Test]
        public void CreateBar_OK_BarDoesNotExistYet_ReturnsTrue()
        {
            var rc = new RestClient(new MockHttpMessageHandler(async (request, cancellationToken) =>
            {
                var responseMessage = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = null
                };

                return await Task.FromResult(responseMessage);
            }));

            Assert.That(rc.CreateBar(new RegisterBarDTO()).Result, Is.True);
        }

        //[Test]
        //public void CreateBar_BadRequest_BarAlreadyExists_ReturnsFalse() //Fix this
        //{
        //    var rc = new RestClient(new MockHttpMessageHandler(async (request, cancellationToken) =>
        //    {
        //        var responseMessage = new HttpResponseMessage(HttpStatusCode.BadRequest)
        //        {
        //            Content = new StringContent("Bar")
        //        };

        //        return await Task.FromResult(responseMessage);
        //    }));

        //    Assert.That(rc.CreateBar(new RegisterBarDTO()), Throws.DuplicateNameException("Bar already exists!"));
        //}

        [Test]
        public void GetBestBarList_OK_ReceivesCorrectAmount()
        {
            var rc = new RestClient(new MockHttpMessageHandler(async (request, cancellationToken) =>
            {
                var responseMessage = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent("[{'BarName':'TestBar'}, {'BarName':'Katrines'}, {'BarName':'Datalogernes'}]")
                };

                return await Task.FromResult(responseMessage);
            }));

            Assert.That(rc.GetBestBarList().Result.Count, Is.EqualTo(3));
        }

        [Test]
        public void GetBestBarList_BadRequest_ReceivesEmptyList()
        {
            var rc = new RestClient(new MockHttpMessageHandler(async (request, cancellationToken) =>
            {
                var responseMessage = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent("[{'BarName':'TestBar'}, {'BarName':'Katrines'}, {'BarName':'Datalogernes'}]")
                };

                return await Task.FromResult(responseMessage);
            }));

            Assert.That(rc.GetBestBarList().Result.Count, Is.EqualTo(0));
        }

        [Test]
        public void GetWorstBarList_OK_ReceivesCorrectAmount()
        {
            var rc = new RestClient(new MockHttpMessageHandler(async (request, cancellationToken) =>
            {
                var responseMessage = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent("[{'BarName':'TestBar'}, {'BarName':'Katrines'}, {'BarName':'Datalogernes'}]")
                };

                return await Task.FromResult(responseMessage);
            }));

            Assert.That(rc.GetWorstBarList().Result.Count, Is.EqualTo(3));
        }

        [Test]
        public void GetWorstBarList_BadRequest_ReceivesEmptyList()
        {
            var rc = new RestClient(new MockHttpMessageHandler(async (request, cancellationToken) =>
            {
                var responseMessage = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent("[{'BarName':'TestBar'}, {'BarName':'Katrines'}, {'BarName':'Datalogernes'}]")
                };

                return await Task.FromResult(responseMessage);
            }));

            Assert.That(rc.GetWorstBarList().Result.Count, Is.EqualTo(0));
        }

        [Test]
        public void GetSpecificBarList_OK_ReceivesCorrectAmount()
        {
            var rc = new RestClient(new MockHttpMessageHandler(async (request, cancellationToken) =>
            {
                var responseMessage = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent("[{'BarName':'TestBar'}, {'BarName':'Katrines'}, {'BarName':'Datalogernes'}]")
                };

                return await Task.FromResult(responseMessage);
            }));

            Assert.That(rc.GetSpecificBarList(1,3).Result.Count, Is.EqualTo(3));
        }

        [Test]
        public void GetSpecificBarList_BadRequest_ReceivesEmptyList()
        {
            var rc = new RestClient(new MockHttpMessageHandler(async (request, cancellationToken) =>
            {
                var responseMessage = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent("[{'BarName':'TestBar'}, {'BarName':'Katrines'}, {'BarName':'Datalogernes'}]")
                };

                return await Task.FromResult(responseMessage);
            }));

            Assert.That(rc.GetSpecificBarList(1,3).Result.Count, Is.EqualTo(0));
        }
    }
}