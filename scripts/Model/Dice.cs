using System.Collections;
using System.Collections.Generic;
using Godot;
using System;

public class Dice 
{
    List<string> description;
    List<float> probability;

    private string state;

    public List<string> Description { get => description; set => description = value; }
    public List<float> Probability { get => probability; set => probability = value; }
    public string State { get => state; set => state = value; }

    public float FindProbabilityFromDescription(string description) {
        for (int i = 0; i < this.description.Count; i++) {
            if (this.description[i].Equals(description)) {
                return probability[i];
            }
        }
        return -1;
    }

    public string GetNextState (OfficialPosition officialPosition) {
        float[] nowProbability = new float[this.description.Count];
        for (int i = 0; i < this.description.Count; i++) {
            nowProbability[i] = (officialPosition.NextOfficialPositionProbability.Probability[i]+ this.Probability[2]) / 2;
        }
        Random rand = new(Guid.NewGuid().GetHashCode());
        float randNum = (float)rand.NextDouble();
        float sumProbability = 0;
        for (int i = 0; i < this.description.Count; i++) {
            sumProbability += nowProbability[i];
            if (randNum < sumProbability) { 
                return this.description[i];
            }
        }
        return null;
    }
}
