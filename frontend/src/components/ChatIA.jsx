import { useState, useRef, useEffect } from "react";
import ReactMarkdown from "react-markdown";

function ChatIA() {
  const [mensajes, setMensajes] = useState([]);
  const [input, setInput] = useState("");
  const chatEndRef = useRef(null);

  const enviarMensaje = async () => {
    if (!input.trim()) return;

    const nuevoMensaje = { role: "user", content: input };
    setMensajes((prev) => [...prev, nuevoMensaje]);

    // Limpiar input inmediatamente
    setInput("");

    try {
      const res = await fetch("http://localhost:5034/api/chat", {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({ pregunta: input }),
      });

      const data = await res.json();
      const respuestaIA = { role: "assistant", content: data.respuesta };
      setMensajes((prev) => [...prev, respuestaIA]);
    } catch (err) {
      console.error(err);
    }
  };

  // Scroll automático al final
  useEffect(() => {
    chatEndRef.current?.scrollIntoView({ behavior: "smooth" });
  }, [mensajes]);

  return (
    <div style={{
      border: "3px solid #333",
      padding: "10px",
      borderRadius: "12px",
      backgroundColor: "#1e1e1e",
      color: "#eee",
      maxWidth: "800px",
      margin: "20px auto"
    }}>
      <h3>Chat con IA</h3>

      <div style={{
        height: "300px",
        overflowY: "auto",
        marginBottom: "10px",
        padding: "5px",
        borderRadius: "5px",
        backgroundColor: "#121212"
      }}>
        {mensajes.map((msg, i) => (
          <div key={i} style={{ textAlign: msg.role === "user" ? "right" : "left", margin: "5px 0" }}>
            <b>{msg.role === "user" ? "Tú" : "IA"}:</b>
            <div style={{ marginTop: "3px" }}>
              {msg.role === "assistant" ? <ReactMarkdown>{msg.content}</ReactMarkdown> : msg.content}
            </div>
          </div>
        ))}
        <div ref={chatEndRef} />
      </div>

      <input
        type="text"
        value={input}
        onChange={(e) => setInput(e.target.value)}
        onKeyDown={(e) => e.key === "Enter" && enviarMensaje()}
        style={{
          width: "80%",
          padding: "5px",
          borderRadius: "5px",
          border: "1px solid #333",
          backgroundColor: "#1e1e1e",
          color: "#eee"
        }}
      />
      <button
        onClick={enviarMensaje}
        style={{
          width: "18%",
          marginLeft: "2%",
          padding: "5px",
          borderRadius: "5px",
          backgroundColor: "#333",
          color: "#eee"
        }}
      >
        Enviar
      </button>
    </div>
  );
}

export default ChatIA;
