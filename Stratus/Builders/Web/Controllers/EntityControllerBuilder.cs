
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Stratus.Builders.Roslyn;

namespace Stratus.Builders.Web.Controllers
{
    public class EntityControllerBuilder
    {
        private static string ENTITY_CONTROLLER_FILE_NAME = "EntityController.txt";
        
        // Todo: root.replacenode should be here or at root builder
        public static ClassDeclarationSyntax Build(string entityName)
        {
            CompilationUnitSyntax unitSyntax = ClassLoader.Load(ENTITY_CONTROLLER_FILE_NAME);
            ClassDeclarationSyntax classDeclaration = unitSyntax.DescendantNodesAndSelf().OfType<ClassDeclarationSyntax>().FirstOrDefault();

            if(classDeclaration != null)
            {
                classDeclaration = classDeclaration.WithIdentifier(SyntaxFactory.Identifier(entityName + "Controller"));
                return classDeclaration;
            }

            throw new NotImplementedException();
        }
    }
}
