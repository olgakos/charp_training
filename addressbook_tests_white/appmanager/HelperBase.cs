﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using AutoItX3Lib;

namespace addressbook_tests_white
{
    public class HelperBase
    {
        protected ApplicationManager manager;

        public HelperBase(ApplicationManager manager)
        {
            this.manager = manager;
        }
    }
}