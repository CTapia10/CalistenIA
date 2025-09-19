import { useEffect, useState } from "react";
import ChatIA from "./ChatIA";

function Rutinas() {
  const [rutinas, setRutinas] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  useEffect(() => {
    fetch("http://localhost:5034/api/rutinas")
      .then((res) => {
        if (!res.ok) throw new Error("Error al cargar rutinas");
        return res.json();
      })
      .then((data) => setRutinas(data))
      .catch((err) => setError(err))
      .finally(() => setLoading(false));
  }, []);

  if (loading) return <p style={{ textAlign: "center", color: "#ccc" }}>Cargando rutinas...</p>;
  if (error) return <p style={{ color: "red", textAlign: "center" }}>Error: {error.message}</p>;

  return (
    <div style={{ border: "3px solid #333", maxWidth: "800px", margin: "auto", color: "#eee", backgroundColor: "#121212", padding: "20px", borderRadius: "10px" }}>
      <h2>Rutinas de Calistenia</h2>
      <ul style={{ listStyle: "none", padding: 0 }}>
        {rutinas.map((r) => (
          <li key={r.id} style={{
            border: "3px solid #333",
            backgroundColor: "#1e1e1e",
            padding: "10px 15px",
            marginBottom: "10px",
            borderRadius: "8px",
            boxShadow: "0 2px 5px rgba(0,0,0,0.5)"
          }}>
            <strong>{r.nombre}</strong>: {Array.isArray(r.ejercicios) ? r.ejercicios.join(", ") : "No hay ejercicios"}
          </li>
        ))}
      </ul>
    </div>
  );
}

export default Rutinas;
