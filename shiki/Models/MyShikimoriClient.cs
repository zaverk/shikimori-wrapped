using Microsoft.Extensions.Logging;
using ShikimoriSharp;
using ShikimoriSharp.Bases;
using ShikimoriSharp.Information;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shiki.Models
{
    public class MyShikimoriClient : ShikimoriClient
    {
        public MyAnimes MyAnimes { get; }
        public MyUsers MyUsers { get; }

        public MyShikimoriClient(ILogger logger, ClientSettings settings) : base(logger, settings)
        {
            MyAnimes = new MyAnimes(Client);
            MyUsers = new MyUsers(Client);
            
        }
    }
}
