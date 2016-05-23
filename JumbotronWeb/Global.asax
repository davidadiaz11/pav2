<%@ Application Language="C#" %>

<script RunAt="server">

    void Application_Start(object sender, EventArgs e)
    {
        Application["nusuarios"] = 0;

        ScriptManager.ScriptResourceMapping.AddDefinition("jquery", new ScriptResourceDefinition
        {
            Path = "~/js/jquery.js",
            DebugPath = "~/js/jquery.js",
            CdnSupportsSecureConnection = true,
            LoadSuccessExpression = "window.jQuery"
        });

    }

    void Application_End(object sender, EventArgs e)
    {
        //  Código que se ejecuta al cerrarse la aplicación

    }

    void Application_Error(object sender, EventArgs e)
    {
        // Código que se ejecuta cuando se produce un error sin procesar

    }

    void Session_Start(object sender, EventArgs e)
    {
        Application.Lock();//esto es para evitar la concurrencia cuando dos usuarios entran
        int nusuarios = Convert.ToInt32(Application["nusuarios"]);
        nusuarios++;
        Application["nusuarios"] = nusuarios;
        Application.UnLock();

    }

    void Session_End(object sender, EventArgs e)
    {
        Application.Lock();//esto es para evitar la concurrencia cuando dos usuarios entran
        int nusuarios = Convert.ToInt32(Application["nusuarios"]);
        nusuarios--;
        Application["nusuarios"] = nusuarios;
        Application.UnLock();

    }

    protected void Application_AuthenticateRequest(object sender, EventArgs e)
    {
        if (HttpContext.Current.User != null)
        {
            var id = HttpContext.Current.User.Identity;
            HttpContext.Current.User = new System.Security.Principal.GenericPrincipal(id, GestorUsuarios.ObtenerRoles(id.Name));
        }
    }
       
</script>
