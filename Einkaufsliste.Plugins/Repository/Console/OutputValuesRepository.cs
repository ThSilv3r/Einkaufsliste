﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Einkaufsliste.ClassLibrary.Repository.Plugin.Console
{
    public interface OutputValuesRepository
    {
        void enterNameMessage();
        void closeEntryMessage();
    }
}