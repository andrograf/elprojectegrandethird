import { FetchData } from "./components/FetchData";
import { Home } from "./components/Home";
import { NavMenu } from "./components/NavMenu";
import { Articles } from './components/Articles';
import { Recipes } from "./components/Recipes";

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
    element: <FetchData />
    },
    {

    path: '/articles',
    element: <Articles />
    },
    {
    path: '/recipes',
    element: <Recipes />

    }
];

export default AppRoutes;
