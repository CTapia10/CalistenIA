import Rutinas from "./components/Rutinas.jsx";
import ChatIA from "./components/ChatIA";

function App() {
  return (
    <div style={{
      padding: "40px",
      fontFamily: "Arial, sans-serif",
      maxWidth: "800px",
      margin: "0 auto",
      backgroundColor: "#121212", // Fondo oscuro global
      color: "#eee",               // Texto claro global
      minHeight: "100vh"
    }}>
      <h1 style={{ textAlign: "center", color: "#eee" }}>CalistenIA 💪</h1>
      <Rutinas />
      <ChatIA darkMode={true} />
    </div>
  );
}

export default App;
