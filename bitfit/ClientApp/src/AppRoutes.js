import { FetchData } from "./components/FetchData";
import { Home } from "./components/Home";
import { NavMenu } from "./components/NavMenu";

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
    }
];

export default AppRoutes;
