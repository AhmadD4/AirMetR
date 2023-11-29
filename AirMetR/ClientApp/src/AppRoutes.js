import Home from "./components/Home";
import CreateProperty from "./pages/Property/Create";
import DeleteProperty from "./pages/Property/Delete";
import PropertyDetail from "./pages/Property/Details"; // import your component
import PropertyList from "./pages/Property/PropertiesTable";
import DeleteReservation from "./pages/Reservations/Delete";
import ReservationsList from "./pages/Reservations/ListReservations";
import ReservationDetail from "./pages/Reservations/ReservationDetail";
import UpdateReservation from "./pages/Reservations/Update";
import YourReservations from "./pages/Reservations/YourReservations";
import UpdateProperty from "./pages/Property/Update";


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
      path: '/properties/2',
      element: <PropertyList />
  },
    {
        path: `/property/update/:id`, // Define the route path with a parameter
        element: <UpdateProperty />    // Assign the PropertyDetail component
    },
  {
    path: `/property/:id`, // Define the route path with a parameter
    element: <PropertyDetail />    // Assign the PropertyDetail component
    },
    {
        path: `/property/delete/:id`, // Define the route path with a parameter
        element: <DeleteProperty />    // Assign the PropertyDetail component
    },
    {
        path: `/reservations/list/:id`, // Define the route path with a parameter
        element: <ReservationsList />    // Assign the PropertyDetail component
    },
    {
        path: `/reservations`, // Define the route path with a parameter
        element: <YourReservations />    // Assign the PropertyDetail component
    },
    {
        path: `/reservation/delete/:id`, // Define the route path with a parameter
        element: <DeleteReservation />    // Assign the PropertyDetail component
    },
    {
        path: `/reservation/detail/:id`, // Define the route path with a parameter
        element: <ReservationDetail />    // Assign the PropertyDetail component
    },
    {
        path: `/reservation/update/:id`, // Define the route path with a parameter
        element: <UpdateReservation />    // Assign the PropertyDetail component
    },

];

export default AppRoutes;
