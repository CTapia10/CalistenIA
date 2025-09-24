import { useEffect, useState } from "react";

function Rutinas() {
  const [rutinas, setRutinas] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  useEffect(() => {
    fetch("http://localhost:5034/api/rutinas") // tu endpoint del backend
      .then((res) => {
        if (!res.ok) throw new Error("Error al cargar rutinas");
        return res.json();
      })
      .then((data) => setRutinas(data))
      .catch((err) => setError(err))
      .finally(() => setLoading(false));
  }, []);

  if (loading) return <p style={{ textAlign: "center" }}>Cargando rutinas...</p>;
  if (error) return <p style={{ color: "red", textAlign: "center" }}>Error: {error.message}</p>;

  return (
    <div>
      <h2 style={{ color: "#555" }}>Rutinas de Calistenia</h2>
      <ul style={{ listStyle: "none", padding: 0 }}>
        {rutinas.map((r) => (
          <li
            key={r.id}
            style={{
              backgroundColor: "#fff",
              padding: "10px 15px",
              marginBottom: "10px",
              borderRadius: "8px",
              boxShadow: "0 2px 5px rgba(0,0,0,0.1)",
            }}
          >
            <strong>{r.nombre}</strong> ({r.dificultad})
            <ul style={{ marginTop: "5px", paddingLeft: "15px" }}>
              {Array.isArray(r.ejercicios) && r.ejercicios.length > 0 ? (
                r.ejercicios.map((e) => <li key={e.id}>{e.nombre}</li>)
              ) : (
                <li>No hay ejercicios</li>
              )}
            </ul>
          </li>
        ))}
      </ul>
    </div>
  );
}

export default Rutinas;
