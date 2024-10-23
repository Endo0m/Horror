using System.Collections.Generic;
using UnityEngine;

public class EventTriggerZone : MonoBehaviour
{
    public enum EventType { Cross, Painting, Book, Ghost }

    [System.Serializable]
    public class EventData
    {
        public EventType EventType;
        public GameObject TargetObject; // Объект для события (крест, картина, книга, призрак)
    }

    [SerializeField] private List<EventData> eventsList = new List<EventData>(); // Список событий
    private bool _eventTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !_eventTriggered)
        {
            TriggerEvent();
            _eventTriggered = true;
        }
    }

    // Метод для активации соответствующего события
    private void TriggerEvent()
    {
        foreach (var eventData in eventsList)
        {
            switch (eventData.EventType)
            {
                case EventType.Cross:
                    var crossEvent = eventData.TargetObject.GetComponent<CrossEvent>();
                    crossEvent?.TriggerEvent();
                    break;
                case EventType.Painting:
                    var paintingEvent = eventData.TargetObject.GetComponent<PaintingEvent>();
                    paintingEvent?.TriggerEvent();
                    break;
                case EventType.Book:
                    var bookEvent = eventData.TargetObject.GetComponent<BookEvent>();
                    bookEvent?.TriggerEvent();
                    break;
                case EventType.Ghost:
                    var ghostEvent = eventData.TargetObject.GetComponent<GhostEvent>();
                    ghostEvent?.TriggerEvent();
                    break;
            }
        }
    }
}
