import { FetchData } from "./components/FetchData";
import { Home } from "./components/Home";
import { NavMenu } from "./components/NavMenu";
import { Articles } from './components/Articles';

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
    }
];

export default AppRoutes;
