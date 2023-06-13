using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvilGenius.TimeTracker.Core.Models;

public record class TimeEntry(string Title, DateTime StartedAt, DateTime EndedAt);
