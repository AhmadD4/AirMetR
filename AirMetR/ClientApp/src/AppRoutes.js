import { Counter } from "./components/Counter";
import { FetchData } from "./components/FetchData";
import Home from "./components/Home";
import CreateProperty from "./pages/Create";
import PropertyDetail from "./pages/Details"; // import your component


const AppRoutes = [
  {
    index: true,
    element: <Home />
  },
  {
      path: '/property/create',
      element: <CreateProperty />
  },
  {
    path: '/fetch-data',
    element: <FetchData />
  },
  {
    path: `/property/:id`, // Define the route path with a parameter
    element: <PropertyDetail />    // Assign the PropertyDetail component
  }
];

export default AppRoutes;
