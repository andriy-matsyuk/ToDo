import { Navigate, Route, Routes } from "react-router-dom"
import { RootLayout } from "./layouts/RootLayout"
import { AllTodos } from "./pages/AllTodos"

function App() {

  return (
    <Routes>

      <Route element={<RootLayout />}>
        <Route path="/" element={<AllTodos />} />
        <Route path="/all" element={<AllTodos />} />
      </Route>

      {/* error route */}
      <Route path="*" element={<Navigate to="/" />} />
    </Routes>
  )
}

export default App
