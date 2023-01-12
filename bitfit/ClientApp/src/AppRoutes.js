import { Counter } from "./components/Counter";
import { FetchData } from "./components/FetchData";
import { Home } from "./components/Home";
import { NavMenu } from "./components/NavMenu";
import DataDisplay from "./components/DataDisplay";

const AppRoutes = [
  {
    index: true,
    element: <Home />
  },
  {
    path: '/counter',
    element: <Counter />
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
        path: '/data',
        element: <DataDisplay />
    }
];

export default AppRoutes;
