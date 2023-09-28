// See https://aka.ms/new-console-template for more information
using ExecuteRoslyn.Declarations.Native;
using Stratus.Declarations.Web.Services;
using System.Reflection.Metadata.Ecma335;

var methodBody = typeof(IBaseService).GetMethod("Build")!.GetMethodBody();

var halt = -1;
