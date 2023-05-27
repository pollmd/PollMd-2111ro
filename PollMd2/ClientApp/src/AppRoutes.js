import { Poll } from "./components/Poll";

const AppRoutes = [
  {
    index: true,
    path: '/polls',
    element: <Poll />
  },
  {
    path: '/addpoll',
    element: <Poll />
  }
];

export default AppRoutes;
