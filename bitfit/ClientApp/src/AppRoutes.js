import { Dashboard } from "./components/Dashboard";
// import { FetchData } from "./components/FetchData";
import { Home } from "./components/Home";
import { NavMenu } from "./components/NavMenu";
import { Articles } from './components/Articles';
import { Recipes } from "./components/Recipes";
import { AspNetTest } from "./components/AspNetTest";
import Register  from "./components/Register";


const AppRoutes = [
    {
    index: true,
    element: <Home />
    },
    {
    path: '/navmenu',
    element: <NavMenu />
    },
    {
        path: '/foods',
        element: <AspNetTest />
    },
    {

    path: '/articles',
    element: <Articles />
    },
    {
    path: '/recipes',
    element: <Recipes />

    },

    {
        path: '/dashboard',
        element: <Dashboard/>
        },
    {
        path: '/registration',
        element: <Register />
    }
];

export default AppRoutes;
