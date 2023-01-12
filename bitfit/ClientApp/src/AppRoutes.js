import { FetchData } from "./components/FetchData";
import { Home } from "./components/Home";
import { NavMenu } from "./components/NavMenu";
import { Recipes } from "./components/Recipes"

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
    path: '/recipes',
    element: <Recipes />
    }
];

export default AppRoutes;
