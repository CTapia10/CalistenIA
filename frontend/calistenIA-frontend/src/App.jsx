import Rutinas from "./components/Rutinas.jsx";

function App() {
  return (
    <div style={{
      padding: "40px",
      fontFamily: "Arial, sans-serif",
      maxWidth: "800px",
      margin: "0 auto",
      backgroundColor: "#f5f5f5",
      minHeight: "100vh"
    }}>
      <h1 style={{ textAlign: "center", color: "#333" }}>CalistenIA 💪</h1>
      <Rutinas />
    </div>
  );
}

export default App;
