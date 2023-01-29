
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace TeamWorkApp.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<TeamWorkApp.Data.TeamWorkAppContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
    } 
}