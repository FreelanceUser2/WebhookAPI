﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace WebhookAPI.App_Start
{
    public class WebHookConfig
    {

        public static void Register(HttpConfiguration config)
        {
            config.InitializeReceiveGitHubWebHooks();
        }
    }
}