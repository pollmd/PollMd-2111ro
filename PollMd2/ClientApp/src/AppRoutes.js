import { Poll } from "./components/Poll";
import { AddPoll } from "./components/AddPoll";

const AppRoutes = [
  {
    index: true,
    path: '/polls',
    element: <Poll />
  },
  {
    path: '/addpoll',
    element: <AddPoll />
  }
];

export default AppRoutes;
